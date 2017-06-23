using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public static GameObject player;

    public GameObject pivot;

    public Rigidbody playerRb;

    public MeshRenderer playerMesh;

    public static int coins = 100;

    public static int coinsScore;

    public Vector3 newPosition;

    private Quaternion localRotation;

	public int coinsSaved;

    public Vector3 pivotPos;


    void Start()
    {
        playerRb = player.GetComponent<Rigidbody>();
        playerMesh = player.GetComponent<MeshRenderer>();

        pivotFollowPlayer.moveSpeed = 40.0f;

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //playerRb.AddForce(0, 5, 0, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //playerRb.AddForce(0, 5, 0, ForceMode.Impulse);
        }

        if(transform.position.y <= -1)
        {
            SceneManager.LoadScene("ReplayMenu");

            Destroy(player);
        }

    }

    public void OnTriggerEnter(Collider other)

    {
        if (other.tag == "hazard")

        {
			PlayerPrefs.SetInt ("Coins", Menu.SavedCoins);

            pivotFollowPlayer.moveSpeed = 0.0f;

            SceneManager.LoadScene("ReplayMenu");

            Destroy(player);
        }

        if(other.tag == "backwards")
        {
            PlayerPrefs.SetInt ("Coins", Menu.SavedCoins);

            pivotFollowPlayer.moveSpeed = 0.0f;

            pivotFollowPlayer.controller.transform.Rotate(0,40,0);

            SceneManager.LoadScene("ReplayMenu");

            Destroy(player);

        }

        if (other.tag == "spring")

        {
            playerRb.AddForce(0, 5, 0, ForceMode.Impulse);
            other.transform.Translate(0, (float)0.1, 0 * Time.deltaTime);
        }


        if (other.tag == "Gems")

		{
			Menu.SavedCoins = Menu.SavedCoins + 1;

			Debug.Log("saved coins are "  + Menu.SavedCoins);

            Destroy(other.gameObject);

            PlayerPrefs.SetInt("Coins", Menu.SavedCoins);

	

        }
    }
}


