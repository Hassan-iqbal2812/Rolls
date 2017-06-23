using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SkinSelection : MonoBehaviour {

    private GameObject[] skinList;
    private int index;

    public static bool PlayGame = false;
    public bool CanChoose1 = true;
    public bool CanChoose2 = false;
    public bool CanChoose3 = false;


    private void Start () {

        index = PlayerPrefs.GetInt("SkinSelected");

        skinList = new GameObject[transform.childCount];

        //fill array with models
        for(int i = 0; i < transform.childCount; i++)
        {
            skinList[i] = transform.GetChild(i).gameObject;
        }

        // toggle off renderer
        foreach (GameObject go in skinList)
            go.SetActive(false);

        // toggle on selected skin
        if (skinList[index])
            skinList[index].SetActive(true);

      

    }
	


	// Update is called once per frame
    void Update()
    {
        RotateCoin();
        Buy();
        CoinUnlock();
    }
	public void ToggleLeft() {

        //Toggle off current model
        skinList[index].SetActive(false);

        index--;
        if (index < 0)
            index = skinList.Length - 1;

        //Toggle on new model
        skinList[index].SetActive(true);
	}

    public void ToggleRight()
    {

        //Toggle off current model
        skinList[index].SetActive(false);

        index++;
        if (index == skinList.Length)
            index = 0;

        //Toggle on new model
        skinList[index].SetActive(true);
    }

    public void Confirm()
    {
        if (CanChoose1 == true && index == 0)
        {
            PlayerPrefs.SetInt("SkinSelected", index);
            SceneManager.LoadScene("GameScene");
            PlayGame = true;
        }
        if (CanChoose2 == true && index == 1)
        {
            PlayerPrefs.SetInt("SkinSelected", index);
            SceneManager.LoadScene("GameScene");
            PlayGame = true;
        }
        if (CanChoose3 == true && index == 2)
        {
            PlayerPrefs.SetInt("SkinSelected", index);
            SceneManager.LoadScene("GameScene");
            PlayGame = true;
        }
    }

    public void CoinUnlock()
    {

        if (PlayerControl.coins >= 150 && index == 1)
        {
            CanChoose2 = true;
        }
        if (PlayerControl.coins >= 100 && index == 2)
        {
            CanChoose3 = true;
        }
    }

    public void RotateCoin()
    {
        if(PlayGame == false)
            transform.Rotate(1, 0, 0 * Time.deltaTime);
    }

    public void Buy()
    {
        if (index == 1)
        {
            CanChoose2 = false;
        }
        if (index == 2)
        {
            CanChoose3 = false;
        }
    }
}
