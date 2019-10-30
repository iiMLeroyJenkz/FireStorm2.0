using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{ 

	

    public void MainMenu ()
    {
        SceneManager.LoadScene(0);

    }

    public void levelOne ()
    {
        SceneManager.LoadScene( 2);
    }



    public void QuitGame ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    
}
