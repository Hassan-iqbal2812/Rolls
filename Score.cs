using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Score : MonoBehaviour
{

    // Use this for initialization

    public static float score = 0.0f;
    public static float DeathScore = 0;

    public Text scoreText;

    public Text coinsText;

    public Text highScoreText;

    public ReplayMenu replayMenu;

	public int LastHighestScore;

    void Start()
    {
		

		Debug.Log("what is my current score" + pivotFollowPlayer.CurrentScore);

		Debug.Log("What is my death score" + pivotFollowPlayer.DeathScore);

		scoreText.text = ((int)PlayerPrefs.GetInt("highest")).ToString();

		highScoreText.text = ((int)PlayerPrefs.GetInt("highest")).ToString();


    }

	public void ReplayGame()
	{
		pivotFollowPlayer.CurrentScore = 0;

		pivotFollowPlayer.isDead = false;

		SceneManager.LoadScene("GameScene");
		
		pivotFollowPlayer.moveSpeed = 40.0f;
	}

	public void MainMenu()
	{
		pivotFollowPlayer.CurrentScore = 0;

		pivotFollowPlayer.isDead = false;

		SceneManager.LoadScene("MainMenu");

		pivotFollowPlayer.moveSpeed = 40.0f;

	}

    // Update is called once per frame
    void Update()
    {

		HighscoreFunc ();

        scoreText.text = ((int)pivotFollowPlayer.CurrentScore).ToString();

		coinsText.text = ((int)PlayerPrefs.GetInt("Coins")).ToString();

		highScoreText.text = ((int)PlayerPrefs.GetInt("highest")).ToString();
    }

	public void HighscoreFunc(){

		if (pivotFollowPlayer.DeathScore > PlayerPrefs.GetInt("highest")){



			pivotFollowPlayer.highScore = pivotFollowPlayer.DeathScore;

			Debug.Log ("Your High score " + pivotFollowPlayer.highScore);

			PlayerPrefs.SetInt ("highest", (int)pivotFollowPlayer.highScore);



		}

	}
}