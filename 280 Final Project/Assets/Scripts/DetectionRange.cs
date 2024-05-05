using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UIElements;

/*
 * Author: [Strong, Hannah]
 * Date last modified: [05/05/2024]
 * Codes for the range that detects the enemy.
 * if the enemy is not in the specified range, then it will not be drawn towards the player
 * if it is, then it will go to the player
 */

/// <summary>
/// Codes for the range that detects the enemy.
/// if the enemy is not in the specified range, then it will not be drawn towards the player
/// if it is, then it will go to the player
/// </summary>
public class DetectionRange : MonoBehaviour
{
    //how far out the enemy can be before kirby's ability takes effect on them
    private float radius = 7f;
    //the angle kirby's ability works, since he can't draw in something that's behind him
    private float viewAngle = 100f;
    //reference to the enemy game object
    public GameObject enemy;
    //checks if the enemy can be drawn in or not
    private bool drawInEnemy;

    /// <summary>
    /// initializes things in the scene when the game is started
    /// </summary>
    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    private void Update()
    {
        DetectEnemy();
    }

    /// <summary>
    /// Detects if an enemy is in range and can be effected by Kirby's inhale ability
    /// </summary>
    private void DetectEnemy()
    {
        //this is for the detection circle around Kirby
        Collider[] inRange = Physics.OverlapSphere(this.transform.position, radius);

        if(inRange.Length != 0)
        {
            Transform enemy = inRange[0].transform;

            Vector3 enemyDirection = (enemy.position - this.transform.position).normalized;

            if (Vector3.Angle(transform.forward, enemyDirection) < viewAngle / 2)
            {
                float enemyDistance = Vector3.Distance(transform.position, enemy.position);

                //raycast from player transform.position
                //limited to the direction and distance of the enemy
                if(!Physics.Raycast(transform.position, enemyDirection, enemyDistance))
                {
                    drawInEnemy = true;
                }
                else
                {
                    drawInEnemy = false;
                }
            }
            else
            {
                drawInEnemy = false;
            }

            Debug.Log("Enemy Dectected");
        }
        else
        {
            if(drawInEnemy)
            {
                drawInEnemy = false;
            }

            Debug.Log("Enemy not detected");
        }
    }
}
