using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: [Strong, Hannah]
 * Date Last Modified: [05/07/2024]
 * Codes for the UI and scene transition for the Read Me panel
 */

public class UIManager : MonoBehaviour
{
    /// <summary>
    /// Codes for the player to quit the feature if they press the quit button
    /// </summary>
    public void QuitFeature()
    {
        Debug.Log("Quitting feature.");
        Application.Quit();
    }

    /// <summary>
    /// allows the player to move from the read me panel to the feature demo
    /// </summary>
    public void Continue()
    {
        SceneManager.LoadScene(1);
    }
}
