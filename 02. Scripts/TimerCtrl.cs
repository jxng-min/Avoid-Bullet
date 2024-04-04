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
    private TextMeshProUGUI m_text;
    void Start()
    {
        
    }

    void Update()
    {
        if(GameManager.game_state != GameManager.GameState.GAMEOVER)
            play_time += Time.deltaTime;

        m_text.text = (play_time * 10).ToString("0000");
    }
}
