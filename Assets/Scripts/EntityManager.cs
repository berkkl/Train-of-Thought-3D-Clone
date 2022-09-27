using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    #region variables

    public float movementSpeed = 5f;
    
    //to make sure entity didn't turn twice
    private float _entityTurnCountdown = 0.1f;
    private float _entityTurnTimer;

    #endregion
    

    private void Update()
    {
        if(_entityTurnTimer >= 0)
        {
            _entityTurnTimer -= Time.deltaTime;
        }
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Right Turn Indicator" && _entityTurnTimer <= 0)
        {
            transform.Rotate(0, 90, 0);
            _entityTurnTimer = _entityTurnCountdown;
        }

        if (collision.gameObject.tag == "Left Turn Indicator" && _entityTurnTimer <= 0)
        {
            transform.Rotate(0, -90, 0);
            _entityTurnTimer = _entityTurnCountdown;
        }
    }
}
