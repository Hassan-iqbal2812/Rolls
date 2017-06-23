using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ReplayMenu : MonoBehaviour
{

    public Text scoreText;
    public Text highScoreText;
    public GameObject thePlayer;
    public PlayerControl playerScript;

    // Use this for initialization
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {
        pivotFollowPlayer.DeathScore = pivotFollowPlayer.CurrentScore;

        //highScoreFunc();
//        Debug.Log("Your death score is " + pivotFollowPlayer.DeathScore);

//        Debug.Log("Your highest score is" + pivotFollowPlayer.highScore);

 //       Debug.Log("Your current score is  "  + pivotFollowPlayer.CurrentScore);

        

    }
    
}
