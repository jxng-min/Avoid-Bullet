using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using _Singleton;

[System.Serializable]
public class Sound
{
    public string m_name;
    public AudioClip m_clip;
}

public class SoundManager : _Singleton.Singleton<SoundManager>
{
    [SerializeField]
    private Sound[] m_effect_sounds;
    [SerializeField]
    private Sound[] m_bgm_sounds;

    [SerializeField]
    private AudioSource m_audio_source_bfm;
    [SerializeField]
    private AudioSource[] m_audio_source_effects;

    [SerializeField]
    private string[] m_play_sound_name;

    void Start()
    {
        m_play_sound_name = new string[m_audio_source_effects.Length];
    }

    public void PlaySE(string _name)
    {
        for(int i = 0; i < m_effect_sounds.Length; i++)
        {
            if(_name == m_effect_sounds[i].m_name)
            {
                for(int j = 0; j < m_audio_source_effects.Length; j++)
                {
                    if(!m_audio_source_effects[j].isPlaying)
                    {
                        m_audio_source_effects[j].clip = m_effect_sounds[i].m_clip;
                        m_audio_source_effects[j].Play();
                        m_play_sound_name[j] = m_effect_sounds[i].m_name;
                        return;
                    }
                }
                return;
            }
        }
    }

    public void PlayerBGM(string _name)
    {
        for(int i = 0; i < m_bgm_sounds.Length; i++)
        {
            if(_name == m_bgm_sounds[i].m_name)
            {
                m_audio_source_bfm.clip = m_bgm_sounds[i].m_clip;
                m_audio_source_bfm.Play();
                return;
            }
        }
    }

    public void StopAllSE()
    {
        for(int i = 0; i < m_audio_source_effects.Length; i++)
        {
            m_audio_source_effects[i].Stop();
        }
    }

    public void StopSE(string _name)
    {
        for(int i = 0; i < m_audio_source_effects.Length; i++)
        {
            if(m_play_sound_name[i] == _name)
            {
                m_audio_source_effects[i].Stop();
                break;
            }
        }
    }

    public void SetBGMVolume(float volume)
    {
        m_audio_source_bfm.volume = volume;
    }

    public void SetSEVolume(float volume)
    {
        for(int i = 0; i < m_audio_source_effects.Length; i++)
            m_audio_source_effects[i].volume = volume;
    }
}