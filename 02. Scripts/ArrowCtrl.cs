using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCtrl : MonoBehaviour
{
    private Rigidbody2D m_rigidbody;
    private float m_move_speed = 3f;

    void Start()
    {
        Invoke("DestroyObject", 5.0f);
    }

    public void SetDirection(Vector3 direction)
    {
        m_rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        m_rigidbody.AddForce(direction * m_move_speed, ForceMode2D.Impulse);
    }

    void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
