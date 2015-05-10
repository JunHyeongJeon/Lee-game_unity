using UnityEngine;
using System.Collections;

public enum GameState
{
    Play,
    Pause,
    End
}


public class GameManager : MonoBehaviour {

    public GameState GS;

    public GUIText Text_Meter;
    public GUIText Text_Gold;

    public GameObject Final_GUI;

    public GUIText Final_Meter;
    public GUIText Final_Gold;

    public GameObject Pause_GUI;

    // 이동 속도
    public float Speed;
    // 이동 거리
    public float Meter;
    // 먹은 금화 수
    public int Gold;
    // 죽인 유닛 수
    public int nKillUnit;

    public void increseKillUnit()
    {
        this.nKillUnit++;
    }

    public void Update()
    {

        if (GS == GameState.Play)
        {
            Meter += Time.deltaTime * Speed;
            Text_Meter.text = string.Format("{0:N0}m", Meter);
        }

    }

    void Start()
    {
        this.nKillUnit = 0;
    }

    public void CoinGet()
    {
        Gold += 1;
        Text_Gold.text = string.Format("{0}", Gold);
    }

    public void GameOver()
    {
        Final_Meter.text = string.Format("{0:N1}", Meter);
        Final_Gold.text = string.Format("{0}", Gold);

        GS = GameState.End;
        Final_GUI.SetActive(true);
    }

    public void Replay()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("PlayScene");
    }

    public void MainGo()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("StartScene");
    }

    public void Pause()
    {
        GS = GameState.Pause;
        Time.timeScale = 0f;
        Pause_GUI.SetActive(true);
    }

    public void UnPause()
    {
        GS = GameState.Play;
        Time.timeScale = 1f;
        Pause_GUI.SetActive(false);
    }


}
