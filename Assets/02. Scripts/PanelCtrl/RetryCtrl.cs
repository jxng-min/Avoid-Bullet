using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryCtrl : MonoBehaviour
{
    public void Setting()
    {
        Time.timeScale = 1.0f;
        TimerCtrl.play_time = 0f;
        GameManager.game_state = GameManager.GameState.PLAYING;
    }
}
