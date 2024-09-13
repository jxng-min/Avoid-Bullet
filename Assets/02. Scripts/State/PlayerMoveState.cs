using System.Collections;
using System.Collections.Generic;
using _State;
using UnityEngine;

public class PlayerMoveState : MonoBehaviour, IPlayerState
{
    private PlayerCtrl m_player_ctrl;

    public void Handle(PlayerCtrl ctrl)
    {
        if(!m_player_ctrl)
            m_player_ctrl = ctrl;

        m_player_ctrl.m_move_dir = transform.position - m_player_ctrl.m_flag_point.transform.position;
        m_player_ctrl.m_move_vec_mag = m_player_ctrl.m_move_dir.magnitude;

        if (m_player_ctrl.m_move_vec_mag > 2.2f)
        {
            Vector2 clamped_pos 
                    = m_player_ctrl.m_flag_point.transform.position + m_player_ctrl.m_move_dir.normalized * 2.15f;
            m_player_ctrl.transform.position = clamped_pos;
        }    
    }
}


