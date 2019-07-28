//Script Developed By Israr Hussain. - *DO NOT REDISTRIBUTE* 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnlockItemsScript : MonoBehaviour {
	//Public variables
	public GameObject locksymbol;
	public GameObject playbutton;
	//public GameObject buynowbutton;
	public int Cost;
	public GameObject Options;
	//-----------------------------------------------
	public string UniqueName; 
	// unique string for saving purposes (UNIQUE NAME must be set to each object)
	// - IF YOU WANT TO RESET THE ITEM BACK TO BEING LOCKED, THEN CHANGE THE UNIQUE NAME TO AGAIN.
	//----------------------------------
	public GameObject NotEnough;
	private bool NotE = false; // STANDS FOR NOT ENOUGH_ DO NOT CHANGE.
	public float WaitT = 1; 
	//AUDIO CLIP CAN BE ADDED HERE. 

	//private Variables.
	public int CoinsValueRetriever;
	private int Number;

	//checker BOOLEAN.
	public bool CoinCheck = false;
	//Make a backup of the script before tweaking
	// tweak the "CoinsPref" to your Own String - (so basically the "PrefString" you use to save the coins the user earns.) 

	void Awake () {
		{
			playbutton.active = false;
			Options.active = false;
			NotEnough.active = false;
			CoinsValueRetriever = PlayerPrefs.GetInt ("CoinsPref");
			Number = PlayerPrefs.GetInt (UniqueName);
	
			if (Number == 1) {
				locksymbol.active = false;
				playbutton.active = true;
				//buynowbutton.active = false;
				Number = 2;
			}
		}
	}



	public void OnBuyButtonPressed () {

		if (CoinsValueRetriever >= Cost) {
			Options.active = true;
		} else {
			//leave options deactivated
			Options.active = false;
			//show user not enough diamonds.
			NotEnough.active = true;
			NotE = true;
			StartCoroutine (NotEnoughWait (WaitT));

		}
		}
	public void No ()
	{
		Options.active = false;
	}

	public void Yes ()
	{
				Number = 1;
				CoinsValueRetriever -= Cost;
		//minus the coins.
		PlayerPrefs.SetInt ("CoinsPref", CoinsValueRetriever);
		//visual changes
			//GetComponent<AudioSource> ().PlayOneShot (CoinsClip);
		locksymbol.active = false;
		playbutton.active = true;
		//buynowbutton.active = false;
		Options.active = false;

		//saving the changes.
		PlayerPrefs.SetInt (UniqueName, Number);
		}

 // END OF PURCHASE.


		//activate this if NotE = true -- hence after coin check
	IEnumerator NotEnoughWait(float WaitT)
	{
		if(NotE)
		{
			yield return new WaitForSeconds(WaitT);
			NotEnough.active = false;
				NotE = false;
		}
	}
}

