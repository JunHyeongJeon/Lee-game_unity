using UnityEngine;
using System.Collections;

public class Enemy_Ctrl : MonoBehaviour
{
    // -- 적 이동 상태 값 0:정지상태, 1:JUMP
    private enum ENEMYDIRECETION
    {
        ENEMYSTOP,
        ENEMYJUMP
    };

    ENEMYDIRECETION direction = ENEMYDIRECETION.ENEMYJUMP;

    // -- 적의 AI 상태 값 0 : 적 추적, 1 : 적 공격, 3 : 출현.
    private enum ENEMYSTATE
    {
        ENEMYTRACE,
        ENEMYATTACK,
        ENEMYRUN,
        ENEMYSPECIALATTACK,
        ENEMYDIE
    }

    ENEMYSTATE state = ENEMYSTATE.ENEMYRUN;

    // 적의 중력 초기값
    private const int STAYGRAVITY = 0;

    // 적의 애니메이터 컨트롤러
    public Animator animator;
    // 적의 움직이는 속도
    float speed = 4.0f;
    // 적의 현재 움직이는 x와 y 방향 좌표
    float moveX, moveY;
    // 현재 적의 Y 좌표
    float fCurrentYPosotion;
    // 캐릭터가 서있는 기준점\
    const float y_base = 0.3f;
    // 적군 가변 중력 속도
    float fGravity = 0.5f;
    // 점프가속
    const float jump_accell = 0.01f;

    // 몬스터의 위치
    private Transform trMonster;
    // 유저의 위치
    private Transform trPlayer;

    // 적군과 아군 사이의 일정 거리가 되면 공격해오는 거리
    private float fAttackDist = 2.0f;
    // 적군과 아군 사이의 일정 거리가 되면 적이 아군을 추적하기 시작함
    private float fTraceDist = 5.0f;
    // Track 구역에 진입하게 되면 바뀌게 되는 적의 이동 속도의 배수
    private float fTraceMultiple = 1.50f;
    // Attack 구역에 진입하게 되면 바뀌게 되는 적의 이동 속도의 배수
    private float fAttackMultiple = .2f;

    void Start()
    {
        trMonster = this.gameObject.GetComponent<Transform>();
        trPlayer = GameObject.FindWithTag("Player").GetComponent<Transform>();

        if (0 < transform.position.y)
        {
            fCurrentYPosotion = transform.position.y;
            direction = ENEMYDIRECETION.ENEMYJUMP;
        }

        StartCoroutine(this.checkEnemyState());
        StartCoroutine(this.enemyAction());
    }

    IEnumerator enemyAction()
    {
        // 적이 죽지 않으면 스테이트 검사를 진행한다.
        while (false == animator.GetBool("Die"))
        {
            yield return null;
        }
    }

    IEnumerator checkEnemyState()
    {
        // 적이 죽지 않으면 스테이트 검사를 진행한다.
        while (false == animator.GetBool("Die"))
        {
            yield return new WaitForSeconds(0.2f);

            float _fDist = Vector3.Distance(trPlayer.position, trMonster.position);

            // 적이 사정거리에 들어옴
            if (_fDist < fAttackDist)
            {
                state = ENEMYSTATE.ENEMYATTACK;
            }
            else if (_fDist < fTraceDist)
            {
                state = ENEMYSTATE.ENEMYTRACE;
            }

        }
    }

    void Update()
    {
        if (ENEMYDIRECETION.ENEMYJUMP == direction)
            JumpProcess();
        if (state == ENEMYSTATE.ENEMYRUN)
        {
            moveX = transform.position.x - (speed * Time.deltaTime);
        }
        else if (state == ENEMYSTATE.ENEMYTRACE)
        {
            moveX = transform.position.x - (speed * Time.deltaTime * fTraceMultiple);
            animator.SetBool("Run", true);
        }
        else if (state == ENEMYSTATE.ENEMYATTACK)
        {
            moveX = transform.position.x - (speed * Time.deltaTime * fAttackMultiple);
            animator.SetBool("TraceAttack", true);
            if(false == animator.GetBool("Attack"))
                BeginAttack();
        }
        else if (state == ENEMYSTATE.ENEMYDIE)
        {
            moveX = transform.position.x - (speed * Time.deltaTime * fAttackMultiple);
        }
        moveY = fCurrentYPosotion;
        transform.position = new Vector3(moveX,
                                          moveY,
                                          transform.position.z);

        if (transform.position.x < -15)
        {
            Destroy(gameObject);
            //if the game object is gone, Destroy
            //if you want you can give another order
        }

    }

    void BeginAttack()
    {
        animator.SetBool("Attack", true);
        GameObject.FindWithTag("Player").GetComponent<Player_Ctrl>().decreaseLife();
        state = ENEMYSTATE.ENEMYDIE;
    }

    void BeginDie()
    {
        animator.SetBool("Die", true);
        GameObject.Destroy(this.gameObject, 1);
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().increseKillUnit();
    }

    void JumpProcess()
    {
        if (fCurrentYPosotion > STAYGRAVITY && direction == ENEMYDIRECETION.ENEMYJUMP)
        {
            fCurrentYPosotion -= fGravity;
            fGravity += jump_accell;
        }
        else
        {
            direction = ENEMYDIRECETION.ENEMYSTOP;
            fCurrentYPosotion = y_base;
            fGravity = STAYGRAVITY;
        }
    }
}
