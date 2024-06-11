using UnityEngine;
using System.Collections.Generic;
using Unity.Collections;

public class CollisionDetection : MonoBehaviour
{
    int collision = 0;

    private void OnCollisionEnter(Collision other)
    {
        collision++;
        Debug.Log("Nombre de collisions: " + collision);

        // Check for collisions on each face
        if (other.contacts.Length > 0) // Check if there are any contact points
        {
            ContactPoint contact = other.contacts[0]; // Access the first contact point

           
        }
    }
}