using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestructor : MonoBehaviour
{

    GameController GC;

    private void Start()
    {
        GC = GameObject.Find("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
    
        GC.IncreaseScore();

    }


}
