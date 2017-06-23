using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour {
    
    public Text highScoreText;
    
	public Text Coins;

	public static int SavedCoins;

	// Use this for initialization
	void Start () {

		SavedCoins = PlayerPrefs.GetInt ("Coins");



		highScoreText.text = ((int)PlayerPrefs.GetInt("highest")).ToString();

		Coins.text = ((int)PlayerPrefs.GetInt("Coins")).ToString();

    }

	public void StartGame(){

		SceneManager.LoadScene ("GameScene");

        pivotFollowPlayer.CurrentScore = 0;
        //PlayerControl.coins = 0;

        SkinSelection.PlayGame = true;

        pivotFollowPlayer.moveSpeed = 40.0f;

	}
    void update()
    {
        Debug.Log("Your highscore is" + pivotFollowPlayer.highScore);

        Debug.Log("You have this many coins" + PlayerControl.coins);

		Debug.Log ("Your Saved amount of coins is" + SavedCoins);

    }
}
