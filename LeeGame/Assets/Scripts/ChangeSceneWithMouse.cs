using UnityEngine;
using System.Collections;

public class ChangeSceneWithMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int i = 0;
		while (i < Input.touchCount) {
			Debug.Log("touch");
		}
		//OnMouseDown ();
	}
	void OnMouseDown() {
		//Application.LoadLevel("SomeLevel");
		Debug.Log("touch");
	}
}