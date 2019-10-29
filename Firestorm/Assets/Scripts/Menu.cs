﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{ 

	public GameObject sonicPrefab;
	public GameObject tailsPrefab;
	public GameObject knucklesPrefab;

    public void MainMenu ()
    {
        SceneManager.LoadScene(0);

    }
    public void CharacterSelection ()
	{
    SceneManager.LoadScene("Character Selection"); 
	}
    public void Options ()
    {
        SceneManager.LoadScene( 2);
    }
    public void HowToPlay ()
    {
        SceneManager.LoadScene( 3);
    }
    public void Play ()
    {
        SceneManager.LoadScene( 4);
    }

	  public void Credits ()
    {
        SceneManager.LoadScene( 6);
    }

	  public void GameOver ()
    {
        SceneManager.LoadScene( 5);
    }


    public void QuitGame ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
	 public void PickSonic ()
    {  
		SceneManager.LoadScene( 4);
		DontDestroyOnLoad(Instantiate(sonicPrefab, new Vector3(0, 2, 0), Quaternion.identity));
      
    }
	 public void PickTails ()
    {
		SceneManager.LoadScene( 4);
		DontDestroyOnLoad(Instantiate(tailsPrefab, new Vector3(0, 2, 0), Quaternion.identity));
        
    }
	 public void PickKnuckles()
    {
		SceneManager.LoadScene( 4);
		DontDestroyOnLoad(Instantiate(knucklesPrefab, new Vector3(0, 2, 0), Quaternion.identity));
        
    }
    
}
