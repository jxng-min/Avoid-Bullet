using System.Collections;
using System.Collections.Generic;
using _State;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public Rigidbody2D m_rigidbody;
    public float m_move_speed = 120.0f;
    public JoyStickValue m_value;
    public GameObject m_flag_point;
    public Vector3 m_move_dir = Vector3.zero;
    public float m_move_vec_mag = 0;

    private IPlayerState m_stop_state, m_move_state, m_pause_state, m_dead_state;
    private PlayerStateContext m_player_state_context;

    void Start()
    {
        m_player_state_context = new PlayerStateContext(this);

        m_stop_state = gameObject.AddComponent<PlayerStopState>();
        m_move_state = gameObject.AddComponent<PlayerMoveState>();
        m_pause_state = gameObject.AddComponent<PlayerPauseState>();
        m_dead_state = gameObject.AddComponent<PlayerDeadState>();

        m_player_state_context.Transition(m_stop_state);
    }

    void Update()
    {
        SetPlayerDirectionAnimation();
        SetPlayerMoveState();
    }

    private void FixedUpdate()
    {
        if(m_move_vec_mag <= 2.2f)
            m_rigidbody.velocity = m_value.m_joy_touch * m_move_speed * Time.deltaTime;
        else
            m_rigidbody.velocity = Vector2.zero;
    }

    public void StopPlayer()
    {
        m_player_state_context.Transition(m_stop_state);
    }

    public void MovePlayer()
    {
        m_player_state_context.Transition(m_move_state);
    }

    public void DeadPlayer()
    {
        m_player_state_context.Transition(m_dead_state);
    }

    void SetPlayerMoveState()
    {
        if(GameManager.game_state != GameManager.GameState.DEAD)
        {
            if(m_value.m_joy_touch == Vector2.zero)
                StopPlayer();
            else
                MovePlayer();
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.CompareTag("OBJECT"))
            DeadPlayer();
    }

    public void SetPlayerDirectionAnimation()
    {
        if(m_value.m_joy_touch.x < 0f)
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        else if(m_value.m_joy_touch.x > 0f)
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);   
    }
}
