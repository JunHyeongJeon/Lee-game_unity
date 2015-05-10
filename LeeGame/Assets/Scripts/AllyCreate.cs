using UnityEngine;
using System.Collections;

public class AllyCreate : MonoBehaviour {
	public GameObject Charactor;
	// Use this for initialization
	public GameObject startPos;
	public UISprite ButtonSprite;
	// Update is called once per frame
	void createAlly () {
		if (ButtonSprite.fillAmount >= 1) {
						GameObject preChar;
						preChar = Instantiate (Charactor, startPos.transform.position, Quaternion.identity)as GameObject;
	
				}
	}
}
