using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        SETTING = 0,
        PLAYING = 1,
        GAMEOVER = 2
    }

    public static GameState game_state;

    [SerializeField]
    private GameObject m_game_over_panel;

    [SerializeField]
    private GameObject m_setting_panel;

    void Start()
    {
        TimerCtrl.play_time = 0.0f;
        Time.timeScale = 1.0f;
        game_state = GameState.PLAYING;
        m_game_over_panel.SetActive(false);
        m_setting_panel.SetActive(false);
    }

    void Update()
    {
        if(game_state == GameState.PLAYING)
        {
            Time.timeScale = 1.0f;
            m_game_over_panel.SetActive(false);
            m_setting_panel.SetActive(false);
        }
        else if(game_state == GameState.GAMEOVER)
        {
            m_game_over_panel.SetActive(true);
        }
        else if(game_state == GameState.SETTING)
        {
            Time.timeScale = 0.0f;
            m_setting_panel.SetActive(true);
        }
    }
}
