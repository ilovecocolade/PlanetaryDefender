using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{

    public GameObject blast;
    private Transform ship;
    public float offset;

    void Start()
    {

        ship = GetComponent<Transform>();
        StartCoroutine(Shoot());

    }

    IEnumerator Shoot()
    {

        yield return new WaitForSeconds(3);

        for (int i = 0; i < 999; i++)
        {

            Instantiate(blast, ship.position + ship.forward*offset, Random.rotation);

            yield return new WaitForSeconds(1);
        }

    }

}
