using UnityEngine;
using System.Collections;

public class Send1 : MonoBehaviour {

    public GameObject Target;
    public string MethodName;

    public void OnMouseDrag()
    {
        Target.SendMessage(MethodName);
    }
}
