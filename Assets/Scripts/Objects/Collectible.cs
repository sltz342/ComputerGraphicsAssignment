using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private Player myPlayer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            myPlayer.GotCoin(1);
            Destroy(gameObject); 
        }

    }

    private float currentRotation;
    private void FixedUpdate()
    {
        currentRotation = transform.rotation.y + 0.5f;
        transform.Rotate(0,currentRotation,0);
    }
}
