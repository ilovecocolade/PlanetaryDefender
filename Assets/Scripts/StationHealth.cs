using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationHealth : MonoBehaviour
{
    private float health;
    public Text stationHealthText;
    public GameObject explosion;
    public GameObject nuke;

    private void Start()
    {
        health = 10000.0f;
    }

    private void Update()
    {

        if (health <= 0.0f) 
        { 
        
            Destroy(gameObject);
            Instantiate(nuke, new Vector3(0, 0, 0), Quaternion.LookRotation(new Vector3(0, 0, 1)));
            Instantiate(nuke, new Vector3(5, 0, 0), Quaternion.LookRotation(new Vector3(0, 0, 1)));
            Instantiate(nuke, new Vector3(10, 0, 0), Quaternion.LookRotation(new Vector3(0, 0, 1)));
            stationHealthText.text = "Press 'R' to restart or 'Q' to quit to main menu";

        }

    }

    public void StationDamage(GameObject Other)
    {

        if (Other.tag == "EnemyBullet")
        {

            health -= 20.0f;
            stationHealthText.text = "Station Health: " + health.ToString();

        }

    
    }

    private void OnTriggerEnter(Collider other)
    {
        StationDamage(other.gameObject);
        Instantiate(explosion, other.gameObject.transform.position, Quaternion.LookRotation(new Vector3(-90, 0, 0)));
        Destroy(other.gameObject);

    }

}
