using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class EntitySpawnManager : MonoBehaviour
{
    #region Singleton & Awake
    
    public static  EntitySpawnManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    #region variables

    public List<Transform> spawnPoints;
    private EntityPooler _entityPooler;
    public float spawnRate = 1f;
    private float _spawnTimer;
    
    #endregion
    
    #region start

    private void Start()
    {
        _entityPooler = EntityPooler.Instance;
        _spawnTimer = spawnRate;
    }
    
    #endregion
    
    #region update

    private void Update()
    {
        if (spawnPoints.Count == 0)
        {
            Debug.Log("Please add spawn point");
        }
        
        _spawnTimer -= Time.deltaTime;
        if (_spawnTimer <= 0) //TODO: add a bool to check if game is over
        {
            _spawnTimer = spawnRate;
            Random r = new Random();
            int randomSpawnPoint = r.Next(0, spawnPoints.Count);

            if (_entityPooler.entities.Count > 0)
            {
                int randomEntityIndex = r.Next(0, _entityPooler.entities.Count);
                _entityPooler.SpawnFromPool(_entityPooler.entities[randomEntityIndex].tag,
                    spawnPoints[randomSpawnPoint].position, Quaternion.identity);
                //if the above does not work then use the below
                _entityPooler.entities[randomEntityIndex].size--;
                if(_entityPooler.entities[randomEntityIndex].size <= 0)
                {
                    _entityPooler.entities.RemoveAt(randomEntityIndex);
                }
            }
            else
            {
                Debug.Log("No more entities to spawn");
            }
        }
    }

    #endregion
    
}
