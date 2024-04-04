using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnerCtrl : MonoBehaviour
{
    [SerializeField]
    private GameObject m_player;

    [SerializeField]
    private GameObject m_arrow;

    private Vector3 m_move_direction;
    void Start()
    {
        SetMoveDirection();
        Invoke("SetPattern", Random.Range(4f, 5f));
    }

    void Update()
    {
        
    }

    void SetMoveDirection()
    {
        if(gameObject.CompareTag("SPAWNER_0"))
            m_move_direction = Vector3.down;
        else if(gameObject.CompareTag("SPAWNER_3"))
            m_move_direction = Vector3.left;
        else if(gameObject.CompareTag("SPAWNER_6"))
            m_move_direction = Vector3.up;
        else if(gameObject.CompareTag("SPAWNER_9"))
            m_move_direction = Vector3.right;
    }

    void SetPattern()
    {
        if(GameManager.game_state == GameManager.GameState.PLAYING)
        {
            int select = Random.Range(1, 5);
            switch(select)
            {
                case 1:
                    Pattern1();
                    break;
                case 2:
                    Pattern2();
                    break;
                case 3:
                    StartCoroutine("Pattern3");
                    break;
                case 4:
                    //Pattern4();
                    break;
            }
            Invoke("SetPattern", Random.Range(3f, 4f));
        }
    }

    // 세로로 발사
    void Pattern1()
    {
        List<GameObject> list = new List<GameObject>();
        Vector2 spawn_position;

        if(gameObject.CompareTag("SPAWNER_0"))
            spawn_position = new Vector2(transform.position.x + Random.Range(-2.5f, 2.6f), transform.position.y);
        else if(gameObject.CompareTag("SPAWNER_3"))
            spawn_position = new Vector2(transform.position.x , transform.position.y + Random.Range(-2.0f, 2.1f));
        else if(gameObject.CompareTag("SPAWNER_6"))
            spawn_position = new Vector2(transform.position.x + Random.Range(-2.5f, 2.6f), transform.position.y);
        else
            spawn_position = new Vector2(transform.position.x, transform.position.y  + Random.Range(-2.0f, 2.1f));

        for(int i = 0; i < 5; i++)
        {
            list.Add(Instantiate(m_arrow, spawn_position, transform.rotation));

            if(gameObject.CompareTag("SPAWNER_6"))
                spawn_position.y -= 0.8f;
            else
                spawn_position.y += 0.8f;
        }

         for(int i = 0; i < 5; i++)
             list[i].GetComponent<ArrowCtrl>().SetDirection(m_move_direction);
    }

    // 가로로 발사
    void Pattern2()
    {
        List<GameObject> list = new List<GameObject>();
        Vector2 spawn_position;

        if(gameObject.CompareTag("SPAWNER_0"))
            spawn_position = new Vector2(transform.position.x + Random.Range(-2.5f, 2.6f), transform.position.y);
        else if(gameObject.CompareTag("SPAWNER_3"))
            spawn_position = new Vector2(transform.position.x, transform.position.y + Random.Range(-1f, 1.1f));
        else if(gameObject.CompareTag("SPAWNER_6"))
            spawn_position = new Vector2(transform.position.x + Random.Range(-2.5f, 2.6f), transform.position.y);
        else
            spawn_position = new Vector2(transform.position.x, transform.position.y + Random.Range(-1f, 1.1f));

        for(int i = 0; i < 5; i++)
        {
            list.Add(Instantiate(m_arrow, spawn_position, transform.rotation));

            if(gameObject.CompareTag("SPAWNER_6"))
                spawn_position.y -= 0.8f;
            else
                spawn_position.y += 0.8f;
        }

         for(int i = 0; i < 5; i++)
             list[i].GetComponent<ArrowCtrl>().SetDirection(m_move_direction);
    }

    // 랜덤 발사
    IEnumerator Pattern3()
    {
        List<GameObject> list = new List<GameObject>();
        Vector2 spawn_position;

        if(gameObject.CompareTag("SPAWNER_0"))
            spawn_position = new Vector2(transform.position.x + Random.Range(-2.5f, 2.6f), transform.position.y);
        else if(gameObject.CompareTag("SPAWNER_3"))
            spawn_position = new Vector2(transform.position.x, transform.position.y + Random.Range(-1f, 1.1f));
        else if(gameObject.CompareTag("SPAWNER_6"))
            spawn_position = new Vector2(transform.position.x + Random.Range(-2.5f, 2.6f), transform.position.y);
        else
            spawn_position = new Vector2(transform.position.x, transform.position.y + Random.Range(-1f, 1.1f));

        for(int i = 0; i < 5; i++)
        {
            Vector3 direction = m_player.transform.position - transform.position;

            list.Add(Instantiate(m_arrow, spawn_position, transform.rotation));
            list[i].GetComponent<ArrowCtrl>().SetDirection(direction.normalized);

            yield return new WaitForSeconds(0.4f);
        }
    }

    // 방사형 발사
    void Pattern4()
    {

    }
}
