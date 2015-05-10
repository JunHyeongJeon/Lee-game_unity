using UnityEngine;
using System.Collections;

public class JangPung_Ctrl : MonoBehaviour
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
        this.transform.Translate(Vector3.left * nSpeed * Time.deltaTime);
        yield return null;
    }
    void OnTriggerEnter(Collider other)
    {
        Animator _animator;
        bool _test;

        try
        {
            _animator = other.GetComponent<Enemy_Ctrl>().animator;
        }
        catch
        {
            try
            {
                _animator = other.GetComponent<Enemy_Sword_Ctrl>().animator;
            }
            catch
            {
                _animator = other.GetComponent<Enemy_Gun_Ctrl>().animator;
            }
        }

        _test = _animator.GetBool("Die");


        if (other.gameObject.name == "Enemy_King(Clone)" && _test == false)
        {
            GameObject.Destroy(this.gameObject);
            other.SendMessage("BeginDie", SendMessageOptions.DontRequireReceiver);
        }

        if (other.gameObject.name == "Enemy_Sword(Clone)" && _test == false)
        {
            GameObject.Destroy(this.gameObject);
            other.SendMessage("BeginDie", SendMessageOptions.DontRequireReceiver);
        }

        if (other.gameObject.name == "Enemy_Gun(Clone)" && _test == false)
        {
            GameObject.Destroy(this.gameObject);
            other.SendMessage("BeginDie", SendMessageOptions.DontRequireReceiver);
        }
    }
}
