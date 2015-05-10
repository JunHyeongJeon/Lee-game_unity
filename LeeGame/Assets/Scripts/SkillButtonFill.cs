using UnityEngine;
using System.Collections;

public class SkillButtonFill : MonoBehaviour {

	public float delayTime;

	public UISprite SkillUI;
	//private bool buttonPressFlag;

	bool press;

	void Update(){
		if (SkillUI.fillAmount < 1)
			SkillUI.fillAmount = SkillUI.fillAmount + Time.deltaTime / delayTime;
				//GetComponent(
		else 
			press = false;
		}


	void buttonPress(){
		if (press == false) {
						press = true;
						SkillUI.fillAmount = 0;
				}
	}
}