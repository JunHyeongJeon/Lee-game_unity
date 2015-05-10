using UnityEngine;
using System.Collections;

public class GameQuiet : MonoBehaviour {

	// Use this for initialization
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
