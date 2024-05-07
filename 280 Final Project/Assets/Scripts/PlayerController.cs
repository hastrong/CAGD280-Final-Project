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

    private float speed = 10f;

    //private float jumpPower = 5f;

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
}
