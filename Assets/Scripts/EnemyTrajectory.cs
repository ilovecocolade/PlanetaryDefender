using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrajectory : MonoBehaviour
{

    public int speed;
    private Rigidbody ship;
    private GameObject player;
    private Vector3 shipInitPos;
    private float totalDistance;
    private float startTime;
    private Vector3 zero;
    public float stopDistance;

    void Start()
    {

        ship = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        shipInitPos = ship.transform.position;
        totalDistance = Vector3.Distance(shipInitPos, player.transform.position);
        startTime = Time.time;
        ship.velocity = ship.transform.forward * speed;
        zero = new Vector3(0, 0, 0);

    }


    void Update()
    {

        float distancePlayer = Vector3.Distance(ship.transform.position, player.transform.position);

        if (distancePlayer < stopDistance && ship.velocity != zero)
        {

            ship.velocity = zero;

        }

    }
}
