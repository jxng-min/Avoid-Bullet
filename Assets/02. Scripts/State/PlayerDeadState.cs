using System.Collections;
using System.Collections.Generic;
using _State;
using UnityEngine;

public class PlayerDeadState : MonoBehaviour, IPlayerState
{
    private PlayerCtrl m_player_ctrl;
    
    public void Handle(PlayerCtrl ctrl)
    {
        if(!m_player_ctrl)
            m_player_ctrl = ctrl;
        
        m_player_ctrl.GetComponent<SECallCtrl>().Click();
        m_player_ctrl.m_rigidbody.velocity = Vector2.zero;
        GameManager.game_state = GameManager.GameState.DEAD;
    }
}