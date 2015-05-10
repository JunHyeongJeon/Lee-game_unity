using UnityEngine;
using System.Collections;

public class Block_Loop : MonoBehaviour
{


    public float Speed = 3;
    public GameObject[] Block;
    public GameObject Ground_A;
	public GameObject Ground_B;

    bool isMove = true;

    void Move()
    {
		Ground_A.transform.Translate(Vector3.left * Speed * Time.deltaTime);
		Ground_B.transform.Translate(Vector3.left * Speed * Time.deltaTime);
		if (Ground_B.transform.position.x <= 0)
        {
			Destroy(Ground_A);
			Ground_A = Ground_B;
            Make();
        }
    }

    void Stop()
    {
        this.isMove = false;

    }

    void Start()
    {
        this.isMove = true;
    }

    void Update()
    {
        if (isMove)
            Move();
    }

    void Make()
    {
        int A = Random.Range(0, Block.Length);
		Ground_B = Instantiate(Block[A], new Vector3(Ground_A.transform.position.x + 30, -5, 0), transform.rotation) as GameObject;

    }
}
