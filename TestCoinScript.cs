//This is a test CoinScript for the example Scene. 
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestCoinScript : MonoBehaviour {

	public int Coins;
	public Text CoinsText;
	public bool Reset = false;
	// Change the PrefString to the Save Coins String, Or Leave it if you do not have one. 
	void Start () {
		//PlayerPrefs.SetInt ("CoinsPref", Coins);
	
	}
	
	// Update is called once per frame
	void Update () {
		{
		Coins = PlayerPrefs.GetInt ("CoinsPref");
		CoinsText.text = "Coins: " + Coins.ToString ();
	}
		{
			if (Reset){
				Coins = 300;
				PlayerPrefs.SetInt ("CoinsPref", Coins);
			}
		}
	}

	public void ResetButton ()
	{
		Reset = true;
}
	}

