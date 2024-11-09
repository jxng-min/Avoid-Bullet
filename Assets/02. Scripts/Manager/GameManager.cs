using System.Collections;
using System.Collections.Generic;
using _Singleton;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : Singleton<GameManager>
{
    public enum GameState
    {
        SETTING, PLAYING, PAUSE, DEAD
    }

    public GameState State { get; private set; }
    public GameObject m_state_canvas;
    public GameObject m_dead_panel;
    public GameObject m_pause_panel;

    [SerializeField]
    private JoyStickValue m_joy_value;

    public List<Vector2> m_bullet_velocity_vec;

    private void Start()
    {
        DontDestroyOnLoad(m_state_canvas);
        Setting();
    }

    public void Setting()
    {
        State = GameState.SETTING;

        m_pause_panel.SetActive(false);
        m_dead_panel.SetActive(false);

        TimerCtrl.m_play_time = 0f;
    }

    public void Playing()
    {
        State = GameState.PLAYING;

        m_pause_panel.SetActive(false);
        m_dead_panel.SetActive(false);
    }

    public void Pause()
    {
        State = GameState.PAUSE;

        FindObjectOfType<PlayerCtrl>().PausePlayer();

        m_pause_panel.SetActive(true);
    }

    public void Dead()
    {
        State = GameState.DEAD;

        GameObject joy_stick = GameObject.FindGameObjectWithTag("JOYSTICK");
        Destroy(joy_stick);
        m_joy_value.m_joy_touch = Vector2.zero;

        FindObjectOfType<PlayerCtrl>().DeadPlayer();

        GameObject[] bullets = GameObject.FindGameObjectsWithTag("OBJECT");
        foreach(GameObject bullet in bullets)
            bullet.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        m_bullet_velocity_vec.Clear();

        m_dead_panel.SetActive(true);

        WebClient11.Instance.Send(Convert.ToInt32(TimerCtrl.m_play_time * 10));
    }
}
