using UnityEngine;
using System.Collections;

public class PauseMeunOnOff : MonoBehaviour {

	// Use this for initialization
	public GameObject PauseExit;
	public GameObject ReGame;
	public GameObject GameExit;

	private bool state = false;
	void MeunOnOff(){
		state = !state;
		PauseExit.SetActive (state);
		ReGame.SetActive(state);
		GameExit.SetActive(state);

	}
}
