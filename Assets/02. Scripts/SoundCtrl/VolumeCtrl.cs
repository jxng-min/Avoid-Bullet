using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeCtrl : MonoBehaviour
{
    private Slider m_slider;

    void Start()
    {
        m_slider = this.gameObject.GetComponent<Slider>();
    }

    public void SetBGMVolume()
    {
        SoundManager.m_instance.SetBGMVolume(m_slider.value);
    }

    public void SetSEVolume()
    {
        SoundManager.m_instance.SetSEVolume(m_slider.value);
    }
}