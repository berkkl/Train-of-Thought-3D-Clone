using UnityEngine;

public class TurnSystem : MonoBehaviour
{
    private Ray _ray;
    private RaycastHit _hit;
    private float _turnCooldown = 0.5f;
    private float _timer;
    private Transform _turnPosition;
    private GameObject _leftTurn;
    private GameObject _rightTurn;
    private bool _isTurnDestroyed, _isTurnPlaced;
    private bool _isEntityTurned;


    private void Start()
    {

        for (int i = 0; i < TurnManager.Instance.turns.Count; i++)
        {
            if (TurnManager.Instance.turns[i].CompareTag("Left Turn"))
            {
                _leftTurn = TurnManager.Instance.turns[i];
            }
            else if (TurnManager.Instance.turns[i].CompareTag("Right Turn"))
            {
                _rightTurn = TurnManager.Instance.turns[i];
            }
        }
    }
    

    private void Update()
    {
        _timer -= Time.deltaTime;
        
        if(_timer<=0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _timer = _turnCooldown;
                _ray = new Ray(Camera.main.ScreenPointToRay(Input.mousePosition).origin, 
                    Camera.main.ScreenPointToRay(Input.mousePosition).direction);
                Debug.DrawRay(_ray.origin, _ray.direction * 100, Color.red, 2f);

                if (Physics.Raycast(_ray, out _hit, 1000f))
                {
                    if(_hit.collider.tag == "Right Turn") 
                    {
                        _turnPosition = _hit.transform.parent.transform;
                        if(!_isTurnDestroyed)
                        {
                            _isTurnDestroyed = true;
                            Destroy(_hit.transform.parent.gameObject);
                        }
                        
                        if (!_isTurnPlaced)
                        {
                            _isTurnPlaced = true;
                            Instantiate(_leftTurn, _turnPosition.position, _turnPosition.rotation);
                        }
                        
                    }
                    else if (_hit.collider.tag == "Left Turn")
                    {
                        _turnPosition = _hit.transform.parent.transform;
                        Destroy(_hit.transform.parent.gameObject);
          
                        Instantiate(_rightTurn, _turnPosition.position, _turnPosition.rotation);
                    }
                }
            }
            _isTurnDestroyed = false;
            _isTurnPlaced = false;
        }
    }
}

