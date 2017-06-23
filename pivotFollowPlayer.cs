using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pivotFollowPlayer : MonoBehaviour
{

    public GameObject player;

    public GameObject pivot;

    public static CharacterController controller;

    public float PiviotPosZ;

    public Vector3 zPos;

    public static float moveSpeed = 40.0f;

    private float maxSpeed = 50.0f;

    private Touch touch;

    public float positionOfPlayerY;

    public static bool isDead = false;

    public static float highScore = 0.0f;

    public static float CurrentScore = 0.0f;

    public static float DeathScore = 0.0f;

    public float Xpos = 0.0f;

    public float Ypos = 0.0f;

    //public Vector3 newPosition;

    private Quaternion localRotation;

    private int lane;


    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();


        touch = Input.GetTouch(0);

        lane = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)

        {

            CurrentScore += Time.deltaTime * 5;

			//Debug.Log ("i am doing something");

        }

        if (isDead == true)
        {
            CurrentScore = DeathScore;
        }

        //Debug.Log("current score is " + CurrentScore);

        localRotation.z = transform.rotation.z;

        controller.Move((Vector3.forward * moveSpeed) * Time.deltaTime);

        if (Input.acceleration.x > 0)
        {
            controller.transform.Rotate(new Vector3(0, 0, Time.deltaTime * -20));
        }

        if (Input.acceleration.x < 0)
        {
            controller.transform.Rotate(new Vector3(0, 0, Time.deltaTime * 20));
        }

        if (Input.touchCount > 0)
        {
            Touch firstTouch = Input.GetTouch(0);

                
            if (firstTouch.phase == TouchPhase.Began)
            {
                if (firstTouch.position.x > Screen.width / 2 && transform.rotation.z <= 0.15 && transform.rotation.z >= -0.15)
                {
                    if (lane < 1)
                    {
                        lane++;
                    }
                }
                else if (firstTouch.position.x < Screen.width / 2 && transform.rotation.z <= 0.15 && transform.rotation.z >= -0.15)
                {
                    if (lane > -1)
                    {
                        lane--;
                    }
                            
                }
            }
        }        

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (lane > -1)
            {
                lane--;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (lane < 1)
                lane++;
        }

        Vector3 newPosition = transform.position;

        newPosition.x = lane;

        transform.position = newPosition;

        PlayerFalling();
    }

    public void PlayerFalling()
    {
        positionOfPlayerY = player.transform.position.y;

        if (positionOfPlayerY <= -2)

        {
			PlayerPrefs.SetInt ("Coins", Menu.SavedCoins);

            SceneManager.LoadScene("ReplayMenu");

            Destroy(player);

            isDead = true;
        }

    }


    public void OnTriggerStay(Collider other)

    {
        if (other.tag == "forwards")
        {
            moveSpeed = maxSpeed;

        }

        /*if (other.tag == "backwards")
        {
			
			PlayerPrefs.SetInt ("Coins", Menu.SavedCoins);

            moveSpeed = 0.0f;

            controller.transform.Rotate(0, 40, 0);

            Destroy(player, 0.5f);

            Invoke("Load", (float)0.5);
        }*/
    }

    public void Load()
    {
        SceneManager.LoadScene("ReplayMenu");
    }

    public void OnTriggerExit()
    {

        moveSpeed = 40.0f;

    }
}