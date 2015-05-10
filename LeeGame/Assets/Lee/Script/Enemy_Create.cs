using UnityEngine;
using System.Collections;

public class Enemy_Create : MonoBehaviour
{
    // 적군 젠타임
    private const float GUNSTART = 1.0f, GUNEND = 3.0f;
    // 아군 젠타임
    private const float SWORDSTART = 2.5f, SWORDEND = 4.2f;
    
    // 생성 패턴에 사용될 개체들
    public GameObject enemySword;
    public GameObject enemyGun;
    public GameObject EnemyBoss;

    Vector3 startPos;

    void Start()
    {
        StartCoroutine(createEnemyGun(1.0f));
        StartCoroutine(createEnemySword(1.0f));
     //   StartCoroutine(createEnemyBoss(1.0f));
        StartCoroutine(createTroops1(1.0f));
    }

    IEnumerator createEnemySword(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        startPos = new Vector3(Random.Range(7.0f, 14.0f), Random.Range(2.0f, 5.0f), 0);
        Instantiate(enemySword, startPos, Quaternion.Euler(0, 0, 0));

        StartCoroutine(createEnemySword(Random.Range(SWORDSTART, SWORDEND)));
    }

    IEnumerator createEnemyGun(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        startPos = new Vector3(Random.Range(7.0f, 14.0f), Random.Range(2.0f, 5.0f), 0);
        Instantiate(enemyGun, startPos, Quaternion.Euler(0, 0, 0));

        StartCoroutine(createEnemyGun(Random.Range(GUNSTART, GUNEND)));
    }

    IEnumerator createEnemyBoss(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        startPos = new Vector3(Random.Range(7.0f, 14.0f), Random.Range(2.0f, 5.0f), 0);
        Instantiate(enemyGun, startPos, Quaternion.Euler(0, 0, 0));

        StartCoroutine(createEnemyBoss(Random.Range(GUNSTART, GUNEND)));
    }

    IEnumerator createTroops1(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }

}

// 강채. 애들 속도 , 부대패턴, 