using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCtrl : MonoBehaviour
{
    [SerializeField] private TMP_Text m_tmp;
    [SerializeField] private string m_txt;

    private void OnEnable()
    {
        m_tmp.text = m_txt + (TimerCtrl.m_play_time * 10).ToString("0000");
    }
}
