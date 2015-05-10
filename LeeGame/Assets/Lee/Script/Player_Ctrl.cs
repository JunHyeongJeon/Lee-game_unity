using UnityEngine;
using System.Collections;
using System.Text;

static class Constants
{
    public const int INIT_KEY_A_PRESS_TIME_NUMBER = 0;
    public const int KEY_A_PRESS_TIME = 20;
    public const int INIT_TOUCH_NUMBER = 0;
}

public enum PlayerState
{
    Run,
    Jump,
    D_Jump,
    Death,
    attack
}
public class Player_Ctrl : MonoBehaviour
{

    public PlayerState PS;
    public float Jump_Power;
    public AudioClip[] Sound;

    public GameObject AnotherSpeaker;

    // 화면 이동 및 정지
    public GameObject goMainCamera;
    public GameObject goBlockLoop;
    public GameObject goSkyRoll;

    // 게임 장풍
    public GameObject goJangPung;
    public Transform tfJangPungPos;

    // 게임매니저
    public GameManager GM;

    // 주인공 캐릭터 에니메이톨
    public Animator animator;

    private int aKeyPressTime;
    private AnimatorStateInfo currentBaseState;

    float y = 0.0f;
    float gravity = 0.0f;
    bool Onflag;

    // 플레이어 생명수 지정 변수들
    private const int nEasyLife = 10;
    private const int nNormarLife = 6;
    private const int nHardLife = 2;

    // 플레이어 생명수 한개점 
    private const int nEndGame = 0;


    public GameObject ButtonJump;
    public GameObject ButtonAttack;


    public int nPlayerlife = nNormarLife;

    // -- 플레이어 이동 상태 값 0:정지상태, 1:JUMP, 2 떨어지는 상태
    private enum PLAYERDIRECETION
    {
        PLAYERSTOP,
        PLAYERJUMP,
        PLAYERDOWN
    };

    // 방향을 정해준다.
    PLAYERDIRECETION direction = PLAYERDIRECETION.PLAYERSTOP;

    // 점프속도
    const float jump_speed = 0.2f;
    // 점프가속
    const float jump_accell = 0.01f;
    // 캐릭터가 서있는 기준점
    const float y_base = 0.5f;
    
    // 델리게이트 및 이벤트 선언
    public delegate void PlayerDieHandler();
    public static event PlayerDieHandler onPlayerDie;

    bool buttonJump;
    bool buttonAttackOn;
    bool buttonAttackOff;
    bool buttonAttackDrag;

    public void decreaseLife()
    {
        this.nPlayerlife--;

        if (0 >= this.nPlayerlife)
            onPlayerDie();
    }

    public void increaseLife()
    {
        this.nPlayerlife++;
    }

    void Start()
    {
        y = y_base;
        aKeyPressTime = Constants.INIT_KEY_A_PRESS_TIME_NUMBER;
        StartCoroutine(this.checkPlayerState());
    }

    IEnumerator checkPlayerState()
    {
        while (false == animator.GetBool("Die"))
        {
            yield return new WaitForSeconds(0.2f);

          //  Debug.Log("test :" + this.nPlayerlife);
            if (this.nPlayerlife <= 0)
            {
                animator.SetBool("Die", true);
                GameObject.Destroy(this.gameObject, 1);
                Gameover();
            }
        }
    }

    void Update()
    {
     //   ButtonAttack.
        JumpProcess();
        if (Input.GetKeyDown(KeyCode.Space)||buttonJump)
        {
            if (PS == PlayerState.Jump)
            {
                PS = PlayerState.D_Jump;
                DoJump();
            }
            else if (PS == PlayerState.Run)
            {
                PS = PlayerState.Jump;
                DoJump();
            }

            buttonJump = false;
        }

   //     else if (buttonAttackOff)
    //    {
     //       buttonAttackOff = false;
     //       attack();
      //  }
        
                else if (Input.GetKeyDown(KeyCode.A) || buttonAttackOn)
                {
                    aKeyPressTime = Constants.INIT_KEY_A_PRESS_TIME_NUMBER;
                    Debug.Log('a');
                    buttonAttackOn = false;

                }

                else if (Input.GetKeyUp(KeyCode.A) || buttonAttackOff)
                {
                    Debug.Log('c');
                    if (PS != PlayerState.attack && aKeyPressTime <= Constants.KEY_A_PRESS_TIME)
                    {
                        attack();
                        goBlockLoop.SendMessage("Stop", SendMessageOptions.DontRequireReceiver);
                        goSkyRoll.SendMessage("Stop", SendMessageOptions.DontRequireReceiver);

                    }
                    else if (PS != PlayerState.attack && aKeyPressTime > Constants.KEY_A_PRESS_TIME)
                    {
                        jangpungAttack();
                        goBlockLoop.SendMessage("Stop", SendMessageOptions.DontRequireReceiver);
                        goSkyRoll.SendMessage("Stop", SendMessageOptions.DontRequireReceiver);
                    }
                      
                    buttonAttackOff = false;
                    buttonAttackDrag = false;
       
                }
            else if (Input.GetKey(KeyCode.A) || buttonAttackDrag)
            {
                //Input.GetKeyDown(KeyCode.A) && PS != PlayerState.attack)
                aKeyPressTime++; //키 눌린 시간 측정
                Debug.Log('b');
            }
                


        else if (Input.touchCount > Constants.INIT_TOUCH_NUMBER)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (PS == PlayerState.Jump)
                {
                    D_Jump();
                }
                else if (PS == PlayerState.Run)
                {
                    PS = PlayerState.Jump;
                    Jump();
                }
            }
        }
        Vector3 pos = gameObject.transform.position;
        pos.y = y;
        gameObject.transform.position = pos;

        if (PS != PlayerState.Death && PS != PlayerState.attack)
        {
            goMainCamera.SendMessage("OnCaremaStart", SendMessageOptions.DontRequireReceiver);
            goSkyRoll.SendMessage("Start", SendMessageOptions.DontRequireReceiver);
            goBlockLoop.SendMessage("Start", SendMessageOptions.DontRequireReceiver);
        }

    }

    void Jump()
    {
        Jump_Power = 700f;
        PS = PlayerState.Jump;
        SoundPlay(0);
    }

    void D_Jump()
    {
        Jump_Power = 200f;
        PS = PlayerState.D_Jump;
        //AnotherSpeaker.SendMessage ("SoundPlay");
        SoundPlay(0);
    }

    void Run()
    {
        PS = PlayerState.Run;
    }

    void attack()
    {
        animator.SetTrigger("Attack");
        StartCoroutine(this.DelayRun());
        SoundPlay(1);

        /*
         * attcack space
         * 
         */

    }

    void jangpungAttack()
    {
        SoundPlay(2);
        animator.SetTrigger("Attack");
        StartCoroutine(this.jangPungAttack());
        StartCoroutine(this.DelayRun());
        // need jangpung destroy !!
    }

    IEnumerator jangPungAttack()
    {
        Vector3 vPosition = this.transform.position;//this.tfJangPungPos.position;

        vPosition.Set(vPosition.x + 1.5f, y, vPosition.z);
        Instantiate(goJangPung, vPosition, this.tfJangPungPos.rotation);
        yield return null;
    }

    IEnumerator DelayRun()
    {
        PS = PlayerState.attack;
        yield return new WaitForSeconds(0.9f);
        PS = PlayerState.Run;
    }

    void CoinGet()
    {
        if (GM != null)
        {
            GM.CoinGet();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Enemy_King(Clone)" && PS == PlayerState.attack)
        {
            other.SendMessage("BeginDie", SendMessageOptions.DontRequireReceiver);
        }

        if (other.gameObject.name == "Enemy_Sword(Clone)" && PS == PlayerState.attack)
        {
            other.SendMessage("BeginDie", SendMessageOptions.DontRequireReceiver);
        }

        if (other.gameObject.name == "Enemy_Gun(Clone)" && PS == PlayerState.attack)
        {
            other.SendMessage("BeginDie", SendMessageOptions.DontRequireReceiver);
        }

        if (other.gameObject.name == "DeathZone" && PS != PlayerState.Death)
        {
            // unit은 반드시 맞아야 죽는다. 따라서 데스존의 조건은 취하한다.
            // Gameover();
        }

    }
    void Gameover()
    {
        PS = PlayerState.Death;
        goMainCamera.SendMessage("OnCameraStop", SendMessageOptions.DontRequireReceiver);

        GM.GameOver();
    }

    void SoundPlay(int num)
    {
        audio.clip = Sound[num];
        audio.Play();
    }

    void DoJump() // 점프키 누를때 1회만 호출
    {
        direction = PLAYERDIRECETION.PLAYERJUMP;
        gravity = jump_speed;
    }

    void JumpProcess()
    {
        switch (direction)
        {
            case PLAYERDIRECETION.PLAYERSTOP: // 2단 점프시 처리
                {
                    if (y > y_base)
                    {
                        if (y >= jump_accell)
                        {
                            y -= gravity;
                        }
                        else
                        {
                            y = y_base;
                            PS = PlayerState.Run;
                        }
                    }
                    break;
                }
            case PLAYERDIRECETION.PLAYERJUMP: // up
                {
                    y += gravity;
                    if (gravity <= 0.0f)
                    {
                        direction = PLAYERDIRECETION.PLAYERDOWN;
                    }
                    else
                    {
                        gravity -= jump_accell;
                    }
                    break;
                }

            case PLAYERDIRECETION.PLAYERDOWN: // down
                {
                    y -= gravity;
                    if (y > y_base)
                    {
                        gravity += jump_accell;
                    }
                    else
                    {
                        direction = PLAYERDIRECETION.PLAYERSTOP;
                        y = y_base;
                        PS = PlayerState.Run;
                    }
                    break;
                }
        }
    }
    void AttackButtonOn()
    {
        buttonAttackOn = true;
    }
    void AttackButtonOff()
    {
        buttonAttackOff = true;
    }
    void AttackButtonDrag()
    {
        buttonAttackDrag = true;
    }
    void JumpButtonOn()
    {
        
    }
    void JumpButtonOff()
    {
        buttonJump = true;
    }
}
