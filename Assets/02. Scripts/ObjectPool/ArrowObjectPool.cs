using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ArrowObjectPool : MonoBehaviour
{
    public int m_max_pool_size = 20;
    public int m_stack_default_capacity = 20;

    public ArrowCtrl m_arrow;
    public GameObject m_player;
    private Vector3 m_move_direction = Vector3.up;

    public IObjectPool<ArrowCtrl> Pool
    {
        get
        {
            if(m_pool == null)
                m_pool = new ObjectPool<ArrowCtrl>(
                                CreatedPooledItem,
                                OnTakeFromPool,
                                OnReturnedToPool,
                                OnDestroyPoolObject,
                                true,
                                m_stack_default_capacity,
                                m_max_pool_size);
            return m_pool;
        }
    }

    private IObjectPool<ArrowCtrl> m_pool;

    private void Start()
    {
        float spawn_start_time = Random.Range(3, 6);
        Invoke("Spawn", spawn_start_time);
    }

    private ArrowCtrl CreatedPooledItem()
    {
        var arrow = Instantiate(m_arrow, transform.position, transform.rotation);
        arrow.Pool = Pool;
        return arrow;
    }

    private void OnReturnedToPool(ArrowCtrl arrow)
    {
        arrow.gameObject.SetActive(false);
    }

    private void OnTakeFromPool(ArrowCtrl arrow)
    {
        arrow.gameObject.SetActive(true);
    }

    private void OnDestroyPoolObject(ArrowCtrl arrow)
    {
        Destroy(arrow.gameObject);
    }

    public void Spawn()
    {
        if(GameManager.Instance.State == GameManager.GameState.PLAYING)
        {
            float deg = 0;
            var amount = Random.Range(1, 10);

            for(int i = 0; i < amount; i++)
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

                ArrowCtrl arrow = Pool.Get();
                arrow.transform.position = transform.position;
                arrow.GetComponent<ArrowCtrl>().SetDirection(new_dir);
            }

            Invoke("Spawn", Random.Range(3f, 5f));
        }
    }
}
