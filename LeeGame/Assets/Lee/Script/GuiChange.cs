using UnityEngine;
using System.Collections;

public class GuiChange : MonoBehaviour {

    public GameObject barOn;
    public GameObject barOff1;
    public GameObject barOff2;

    float zOn = -1f;
    float zOff = 0f;
    public void OnMouseDown()
    {
        Vector3 posOn = barOn.transform.position;
        posOn.z = zOn;
        barOn.transform.position = posOn;

        Vector3 posOff1 = barOff1.transform.position;
        posOff1.z = zOff;
        barOff1.transform.position = posOff1;

        Vector3 posOff2 = barOff2.transform.position;
        posOff2.z = zOff;
        barOff2.transform.position = posOff2;

    
    }
}
