using UnityEngine;
using System.Collections;

public class FadeEvent : MonoBehaviour {
	
	private UISprite m_Fade;
	public float m_fDuration = 3.0f;
	public string SceneName;
	
	// Use this for initialization
	void Start () {

						m_Fade = GameObject.Find ("FadeObject").GetComponent<UISprite> ();
						StartCoroutine (FadeOut ());
				
	}
	
	IEnumerator FadeOut()
	{
		// Fade In
		TweenAlpha.Begin (m_Fade.gameObject, m_fDuration, 0.0f);
		yield return new WaitForSeconds( m_fDuration );
		
		// Fade Out
		TweenAlpha.Begin (m_Fade.gameObject, m_fDuration, 1f);
		yield return new WaitForSeconds( m_fDuration );
		
		NextSceneCall();
	}
	
	void NextSceneCall()
	{
		Application.LoadLevel(SceneName);
	}
}