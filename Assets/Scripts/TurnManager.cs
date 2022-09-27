using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{

    public static TurnManager Instance;

    private void Awake()
    {
        Instance = this;
    }


    public List<GameObject> turns;
}