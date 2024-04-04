using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private Rigidbody2D m_rigidbody;
    private float m_move_speed = 150.0f;

    public Vector2 m_move_vec;
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        m_move_vec = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        if(GameManager.game_state != GameManager.GameState.GAMEOVER 
            || GameManager.game_state != GameManager.GameState.SETTING)
            SetPlayerDirectionAnimation();
    }

    void FixedUpdate()
    {
        if(GameManager.game_state != GameManager.GameState.GAMEOVER)
            m_rigidbody.velocity = m_move_vec * m_move_speed * Time.deltaTime;
            
        else
            m_rigidbody.velocity = new Vector2(0, 0);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.CompareTag("OBJECT"))
        {
            GameManager.game_state = GameManager.GameState.GAMEOVER;
        }
    }

    void SetPlayerDirectionAnimation()
    {
        if(m_move_vec.x < 0.0f)
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        else if(m_move_vec.x > 0.0f)
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
    }
}
