using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SECallCtrl : MonoBehaviour
{
    [SerializeField]
    private string m_name; 
    public void Click()
    {
        SoundManager.m_instance.PlaySE(m_name);
    }
}