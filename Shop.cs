using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shop : MonoBehaviour {

    public GameObject[] Coins;
    private List<GameObject> CoinsList;

    // Use this for initialization
    void Start () {

        CoinsList = new List<GameObject>();

    }
	
	// Update is called once per frame
	void Update () {

        rotateCoins();


    }

    private void rotateCoins()
    {
        GameObject Robj;

        Robj = (Coins[0]);

        Robj.transform.Rotate(1, 0, 0 * Time.deltaTime);

    }
}
