using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Singleton;

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource m_effect;

    private AudioClip m_button_click;
    private AudioClip m_player_dead;

    private void Start()
    {
        m_button_click = Resources.Load<AudioClip>("07. Audios/Button_Click");
        m_player_dead = Resources.Load<AudioClip>("07. Audios/Player_Dead");
    }

    public void ButtonClick()
    {
        m_effect.PlayOneShot(m_button_click);
    }

    public void Player_Dead()
    {
        m_effect.PlayOneShot(m_player_dead);
    }
}