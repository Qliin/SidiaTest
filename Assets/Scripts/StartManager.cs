using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour 
{
	public GameObject confirmExit;

	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			confirmExit.SetActive(true);
		}
	}

	public void DontExitGame()
	{
		confirmExit.SetActive(false);
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
