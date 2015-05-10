using UnityEngine;
using System.Collections;

public class MouseClickChange : MonoBehaviour {


	public string SceneName;
	// Use this for initialization
	 void OnMouseDown() {
		Application.LoadLevel("SceneName");
		Debug.Log ("a");
	}

	void Update(){
			}
}
