using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ArrowCtrl : MonoBehaviour
{
    public IObjectPool<ArrowCtrl> Pool { get; set; }

    private Rigidbody2D m_rigidbody;
    private float m_move_speed = 2f;
    private float m_time_to_self_destruct = 3f;

    private void OnEnable()
    {
        m_rigidbody = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(SelfDestruct());
    }

    private void OnDisable()
    {
        ResetArrow();
    }

    private IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(m_time_to_self_destruct);
        ReturnToPool();
    }

    private void ReturnToPool()
    {
        Pool.Release(this);
    }

    private void ResetArrow()
    {
        m_rigidbody.velocity = Vector2.zero;
    }

    public void SetDirection(Vector3 direction)
    {
        m_rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        m_rigidbody.AddForce(direction * m_move_speed, ForceMode2D.Impulse);
    }
}
