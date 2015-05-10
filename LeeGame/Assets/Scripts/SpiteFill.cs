using UnityEngine;
using System.Collections;

public class SpiteFill : MonoBehaviour {


	public float delayTime;	
	public UISprite sprite;
	// Use this for initialization
	void Awake(){
				sprite.fillAmount = 1;
		}  
	void Update(){
				if (sprite.fillAmount < 1)
						sprite.fillAmount = sprite.fillAmount + Time.deltaTime / delayTime;
	}
}
  