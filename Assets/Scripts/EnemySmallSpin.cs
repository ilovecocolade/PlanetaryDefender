using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmallSpin : MonoBehaviour
{

    private Rigidbody ship;

    void Start()
    {
        ship = GetComponent<Rigidbody>();
    }

    void Update()
    {

        ship.angularVelocity = ship.transform.forward * 5;

    }
}