using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashDestructor : MonoBehaviour
{

    public float lifetime;

    void Start()
    {

        Destroy(gameObject, lifetime);

    }
}
