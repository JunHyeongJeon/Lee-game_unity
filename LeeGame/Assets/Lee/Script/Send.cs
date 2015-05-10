using UnityEngine;
using System.Collections;

public class Send : MonoBehaviour {

    public GameObject Target;
    public string MethodName1;
    public string MethodName2;
    public void OnMouseDown()
    {
        Target.SendMessage(MethodName1);
    }
    public void OnMouseUp()
    {
        Target.SendMessage(MethodName2);
    }
}
