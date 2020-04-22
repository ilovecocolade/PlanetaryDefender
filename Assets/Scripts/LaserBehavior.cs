using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehavior : MonoBehaviour
{

    private LineRenderer laserRenderer;
    public GameObject Player;
    private bool laserFire;
    private float nextDamage;


    private void Start()
    {

        laserRenderer = GetComponent<LineRenderer>();
        laserFire = Player.GetComponent<PlayerController>().laserFire;

    }


    void Update()
    {

       laserFire = Player.GetComponent<PlayerController>().laserFire;


            RaycastHit target;

        if (laserFire)
        {
            if (Physics.Raycast(transform.position, transform.forward, out target))
            {
                if (target.collider)
                {
                    laserRenderer.SetPosition(1, new Vector3(0, 0, target.distance * 5));

                    if (Time.time > nextDamage && target.collider.gameObject.tag == "Enemy") 
                    {

                        nextDamage = Time.time + 0.5f;
                        GameObject Enemy = target.collider.gameObject;
                        EnemyHealth enemyHealth = Enemy.GetComponent<EnemyHealth>();
                        enemyHealth.EnemyDamage(gameObject);

                    }

                }
            }
            else laserRenderer.SetPosition(1, new Vector3(0, 0, 5000));

        } 
        else laserRenderer.SetPosition(1, new Vector3(0, 0, 1));
    }
}
