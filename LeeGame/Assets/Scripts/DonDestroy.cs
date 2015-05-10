using UnityEngine;
using System.Collections;

public class DonDestroy : MonoBehaviour {

	// Use this for initialization
	public GameObject GameManager;

	void Update(){
		if (Application.loadedLevel <= 14) {
						DontDestroyOnLoad (GameManager);
				} else
						Destroy (GameManager);
	}
}
