using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerCtrl : MonoBehaviour
{
    public static float play_time;

    [SerializeField]
    private TextMeshProUGUI m_score;
    public string m_text;

    void Update()
    {
        if(GameManager.game_state != GameManager.GameState.DEAD)
            play_time += Time.deltaTime;

        m_score.text = m_text + (play_time * 10).ToString("0000");
    }
}
