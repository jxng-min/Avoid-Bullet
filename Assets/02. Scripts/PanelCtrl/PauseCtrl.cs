using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCtrl : MonoBehaviour
{
    public void Pause()
    {
        if(GameManager.game_state != GameManager.GameState.PAUSE)
        {
            SoundManager.m_instance.PlaySE("Button");
            GameManager.game_state = GameManager.GameState.PAUSE;
        }
    }

    public void PauseCancel()
    {
        if(GameManager.game_state == GameManager.GameState.PAUSE)
        {
            SoundManager.m_instance.PlaySE("Button");
            GameManager.game_state = GameManager.GameState.PLAYING;
        }
    }
}
