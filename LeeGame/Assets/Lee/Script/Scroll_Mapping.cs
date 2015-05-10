using UnityEngine;
using System.Collections;

public class Scroll_Mapping : MonoBehaviour {


    public float ScrollSpeed = 0.5f;
    float Target_Offset;
    bool isLoop = true;

	// Use this for initialization

	// Update is called once per frame
	void Update () {
        if (isLoop)
        {
            Target_Offset += Time.deltaTime * ScrollSpeed;
            renderer.material.mainTextureOffset = new Vector2(Target_Offset, 0);
        }
	}

    void Stop()
    {
        isLoop = false;
    }

    void Start()
    {
        isLoop = true;
    }
}
