using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerCtrl : MonoBehaviour
{
    public static float m_play_time;

    [SerializeField]
    private TextMeshProUGUI m_score;

    void Update()
    {
        if(GameManager.Instance.State == GameManager.GameState.PLAYING)
        {
            m_play_time += Time.deltaTime;
            m_score.text = (m_play_time * 10).ToString("0000");
        }
    }
}
