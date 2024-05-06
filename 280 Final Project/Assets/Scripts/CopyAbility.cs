using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Strong, Hannah]
 * Date Last Modified: [05/06/2024]
 * codes for the transition from normal kirby to copy ability kirby
 */

/// <summary>
/// codes for the transition from normal kirby to copy ability kirby
/// </summary>
public class CopyAbility : MonoBehaviour
{
    //reference to the sword copy ability
    public GameObject sword;
    
    // Start is called before the first frame update
    void Start()
    {
        sword = transform.Find("Sword").gameObject;

        SwordCopyOff();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;

        if(other.tag == "Enemy")
        {
            SwordCopyOn();
        }
    }

    private void SwordCopyOn()
    {
        sword.SetActive(true);
    }

    private void SwordCopyOff()
    {
        sword.SetActive(false);
    }

    bool IsCopyActive()
    {
        return sword.activeSelf;
    }
}
