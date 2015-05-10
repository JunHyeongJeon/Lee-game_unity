using UnityEngine;
using System.Collections;

public class Bullet_Ctrl: MonoBehaviour
{

    public int nDamage = 1;
    public int nSpeed = 4;

    public GameObject goEnemy_Ctrl;
    public GameObject JangPung;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(this.Move());
    }

    IEnumerator Move()
    {
        this.transform.Translate(Vector3.right * -nSpeed * Time.deltaTime);
        yield return null;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Lee_King" )
        {
            GameObject.Destroy(this.gameObject);
            other.SendMessage("decreaseLife", SendMessageOptions.DontRequireReceiver);
        }
    }
}
