using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour
{

    // Use this for initialization

    public Camera camera;
    public GameObject player;

    public float speed = 1f;
    float cameraSize = 5f;

    public PlayerState PS;
    bool isCamera = true;

    void Update()
    {
      //  camera.orthographicSize = 5f + player.transform.position.y;
        if (isCamera)
        {
         //   cameraSize = 5f + player.transform.position.y;
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, cameraSize, Time.deltaTime / speed);
        }
    }

    void OnCameraStop()
    {
        isCamera = false;
    }

    void OnCameraStart()
    {
        isCamera = true;
    }

}
