using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlastBehaviour : MonoBehaviour
{

    public float lifetime;
    public float muzzleVelocity;

    private void Start()
    {

        Destroy(gameObject, lifetime);
        Rigidbody blast = GetComponent<Rigidbody>();
        Vector3 aim = new Vector3(3, 0 ,0) - blast.transform.position;
        blast.velocity = aim * muzzleVelocity;

    }

}