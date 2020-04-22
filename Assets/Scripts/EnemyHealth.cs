using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float health;
    public float gunDamage = 60.0f;
    public float laserDamage = 30.0f;
    public float barrageDamage = 100.0f;
    public GameObject explosion;

    private void Update()
    {

        if (health <= 0.0f) 
        { 
        
            Destroy(gameObject);
            Instantiate(explosion, gameObject.transform.position, Random.rotation);

        }

    }

    public void EnemyDamage(GameObject Other)
    {

        if (Other.tag == "Barrage") { health -= barrageDamage; }
        if (Other.tag == "Bullet") { health -= gunDamage / 40; }
        if (Other.tag == "Laser") { health -= laserDamage / 4; }

    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyDamage(other.gameObject);
        Destroy(other);

    }
}
