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
    public void QuitFeature()
    {
        Debug.Log("Quitting feature.");
        Application.Quit();
    }

    public void Continue()
    {
        SceneManager.LoadScene(1);
    }
}
