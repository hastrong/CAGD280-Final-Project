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
    //This will be Kirby/player
    public GameObject poi;
    //u value for interpolation
    public float u = 0.1f;
    //interpolation vector values
    public Vector3 p0, p1, p01;

    /// <summary>
    /// codes for collision events and what happens when objects interact
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;

        if(other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Updates the scene once per frame
    /// </summary>
    public void Update()
    {
        //DrawIn();

        PlayerController pc = poi.GetComponent<PlayerController>();
        bool inhale = pc.inhale;

        if (inhale)
        {
            p0 = this.transform.position;
            p1 = poi.transform.position;

            p01 = (1 - u) * p0 + u * p1;

            this.transform.position = p01;
        }
    }
}
