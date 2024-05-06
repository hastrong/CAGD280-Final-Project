using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Strong, Hannah]
 * Date Last Modified: [05/02/2024]
 * Codes for the enemy actions and interactions
 */

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;

        if(other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
