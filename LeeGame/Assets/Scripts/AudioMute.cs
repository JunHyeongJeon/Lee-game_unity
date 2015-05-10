using UnityEngine;
using System.Collections;

public class AudioMute : MonoBehaviour {
	private bool OnOff = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (OnOff)
						audio.volume = 1.0f;
			else
						audio.volume = 0.0f;
	}
}
