using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Author: [Strong, Hannah]
 * Date Last Modified: [04/21/2024]
 * Codes for the player movements for Kirby.
 */

/// <summary>
/// Codes for player inputs in the game scene.
/// </summary>
public class PlayerController : MonoBehaviour
{
    //Variables:
    // References the rigidbody belonging to the game object this script is attached to.
    private Rigidbody sphereRigidbody;
    // References the scriptable object PlayerInput.
    private PlayerInput input;
    //movement speed
    private float speed = 10f;
    //how far out the range of detection extends
    private float detectionRange = 10f;
    //if the enemy can be inhaled/in range or not
    private bool canSeeEnemy = false;
    //if inhale ability is active
    public bool inhale = false;

    public Animation swordAnimation;

    

    /// <summary>
    /// Initializes things in the scene.
    /// </summary>
    private void Awake()
    {
        sphereRigidbody = this.GetComponent<Rigidbody>();

        input = new PlayerInput();

        input.Enable();
    }

    /// <summary>
    /// Continuously checks the code here once per frame for any updates that are needed.
    /// </summary>
    private void Update()
    {
        Vector2 myVector = input.InGame.Move.ReadValue<Vector2>();

        //Codes for the wasd Vector3 movement.
        sphereRigidbody.transform.Translate(new Vector3(myVector.x, 0, myVector.y) * speed * Time.deltaTime);

        Collider[] enemyInRange = Physics.OverlapSphere(transform.position, detectionRange);

        foreach (Collider c in enemyInRange)
        {
            if (c.CompareTag("Enemy"))
            {
                float signedAngle = Vector3.Angle(transform.forward, c.transform.position - transform.position);

                canSeeEnemy = true;
                Debug.Log("Enemy in range");
            }
        }
    }

    /// <summary>
    /// Codes for the jumping input action.
    /// </summary>
    /// <param name="context"></param>
    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            //sphereRigidbody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
            //sphereRigidbody.velocity = new Vector2(sphereRigidbody.velocity.x, jumpPower);
            sphereRigidbody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
    }

    /// <summary>
    /// codes for inhale to work only if the q button is pressed and the enemy is in range
    /// </summary>
    /// <param name="context"></param>
    public void Inhale(InputAction.CallbackContext context)
    {
        if(context.performed && canSeeEnemy == true)
        {
            inhale = true;
            
            Debug.Log("Inhale");
        }
    }

    private void Attack(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            swordAnimation.Play("SwordAnimation");
        }
        
    }
}
