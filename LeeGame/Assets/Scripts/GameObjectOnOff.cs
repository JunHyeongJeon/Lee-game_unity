using UnityEngine;
using System.Collections;

public class GameObjectOnOff : MonoBehaviour {

	// Use this for initialization
	public GameObject gameobjectOn;
	public GameObject gameobjectOff;
	void fgameobjectOnOff(){
		gameobjectOn.active = true;

		gameobjectOff.active = false;
	}


}
