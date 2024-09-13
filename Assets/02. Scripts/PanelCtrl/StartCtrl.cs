using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCtrl : MonoBehaviour
{
    public void Setting()
    {
        GameManager.game_state = GameManager.GameState.PLAYING;
    }
}