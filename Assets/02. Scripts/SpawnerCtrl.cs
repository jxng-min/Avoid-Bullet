using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Android;

public class SpawnerCtrl : MonoBehaviour
{
    public GameObject m_player;

    public GameObject m_arrow;

    private Vector3 m_move_direction = Vector3.up;

    public static int arrow_count;

    private void Start()
    {
        Invoke("SetArrowDirection", Random.Range(4f, 5f));
    }

    private void Update()
    {
        arrow_count = 3 + (int)(TimerCtrl.play_time) / 100;
    }

    void SetArrowDirection()
    {
        if(GameManager.game_state == GameManager.GameState.PLAYING)
        {
            float deg = 0;
            for(int i = 0; i < arrow_count; i++)
            {
                if(gameObject.CompareTag("SPAWNER_0"))
                    deg = Random.Range(135f, 225f);
                else if(gameObject.CompareTag("SPAWNER_3"))
                    deg = Random.Range(225f, 315f);
                else if(gameObject.CompareTag("SPAWNER_6"))
                    if(Random.value < 0.5f)
                        deg = Random.Range(315f, 360f);
                    else
                        deg = Random.Range(0f, 45f);
                else if(gameObject.CompareTag("SPAWNER_9"))
                    deg = Random.Range(45f, 135f);

                float rad = deg * Mathf.PI / 180f;

                Vector3 new_dir = new Vector3(
                    m_move_direction.x * Mathf.Cos(rad) - m_move_direction.y * Mathf.Sin(rad),
                    m_move_direction.x * Mathf.Sin(rad) + m_move_direction.y * Mathf.Cos(rad),
                    m_move_direction.z
                );

                GameObject temp_arrow = Instantiate(m_arrow, transform.position, transform.rotation);
                temp_arrow.GetComponent<ArrowCtrl>().SetDirection(new_dir);
            }

            Invoke("SetArrowDirection", Random.Range(3f, 4f)); 
        }
    }
}
