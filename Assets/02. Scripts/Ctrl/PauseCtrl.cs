using System.Collections;
using System.Collections.Generic;
using _EventBus;
using UnityEngine;

public class PauseCtrl : MonoBehaviour
{
    public void Pause()
    {
        SoundManager.Instance.ButtonClick();

        if(GameManager.Instance.State == GameManager.GameState.PLAYING)
        {
            GameEventBus.Publish(GameEventType.PAUSE);

            GameObject[] bullets = GameObject.FindGameObjectsWithTag("OBJECT");
            for(int i = 0; i < bullets.Length; i++)
            {
                GameManager.Instance.m_bullet_velocity_vec.Add(bullets[i].GetComponent<Rigidbody2D>().velocity);
                bullets[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
        else if(GameManager.Instance.State == GameManager.GameState.PAUSE)
        {
            GameEventBus.Publish(GameEventType.PLAYING);

            GameObject[] bullets = GameObject.FindGameObjectsWithTag("OBJECT");
            for(int i = 0; i < bullets.Length; i++)
                bullets[i].GetComponent<Rigidbody2D>().velocity = GameManager.Instance.m_bullet_velocity_vec[i];
            GameManager.Instance.m_bullet_velocity_vec.Clear();
        }
    }
}
