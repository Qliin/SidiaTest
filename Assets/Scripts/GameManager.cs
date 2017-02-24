using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
	public GameObject runningCanvas;
	public GameObject pauseCanvas;
	public GameObject gameOverCanvas;

	public Text overScoreTxt;
	public Text highScoreTxt;
	public Text currentScoreTxt;

	public GameObject reticle;

	private float currentScore = 0;
	private float highScore;

	void Awake()
	{			
		GetHighScore();
	}

	void Update()
	{
		currentScore += Time.deltaTime;
		currentScoreTxt.text = currentScore.ToString("F1");

		if(Input.GetKeyDown(KeyCode.D))
		{
			PlayerPrefs.DeleteAll();
		}
	}

	//PauseMenu
	public void PauseGame()
	{
		Time.timeScale = 0;
		runningCanvas.SendMessage("ResetPosition");
		pauseCanvas.SetActive(true);
	}

	public void Continue()
	{
		Time.timeScale = 1;
		pauseCanvas.SendMessage("ResetPosition");
		runningCanvas.SetActive(true);
	}

	public void Exit()
	{
		Time.timeScale = 1;
		SceneController.instance.LoadScene("Start");
	}

	public void PlayAgain()
	{
		Time.timeScale = 1;
		SceneController.instance.LoadScene("Game");
	}

	void OnGameOver()
	{
		runningCanvas.SendMessage("ResetPosition");

		float runScore = currentScore;

		if(runScore > highScore)
		{
			highScore = runScore;
			PlayerPrefs.SetFloat("highscore", highScore);
		}

		gameOverCanvas.SetActive(true);
		overScoreTxt.text = runScore.ToString("F1");
		highScoreTxt.text = highScore.ToString("F1");
	}

	void GetHighScore()
	{
		if(PlayerPrefs.HasKey("highscore"))
		{
			highScore = PlayerPrefs.GetFloat("highscore");
		}
		else
		{
			highScore = 0;
		}
	}
}