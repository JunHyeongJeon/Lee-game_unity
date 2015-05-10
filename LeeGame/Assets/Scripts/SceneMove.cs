using UnityEngine;
using System.Collections;

public class SceneMove : MonoBehaviour {
	
	public string SceneName;
	
	public void OnMouseDown(){
	
	Application.LoadLevel( SceneName );		
		
	}

	void Scenemove(){
		
		Application.LoadLevel( SceneName );		

	}
	void SceneCurrentmove(){
				Application.LoadLevel (Application.loadedLevel);
		}

}