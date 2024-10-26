using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Singleton;
using WebSocketSharp;
using System;

public class PlayerData
{
    public string userId;
    public string gameCategory;
    public int score;
}

public class WebSocketClient : Singleton<WebSocketClient>
{
    private WebSocket m_web_socket;
    public PlayerData m_data;

    private void Start()
    {
        m_web_socket = new WebSocket("ws://localhost:7777");
        m_data = new PlayerData();
        m_web_socket.Connect();
        m_web_socket.OnMessage += Call;
    }

    private void Call(object sender, MessageEventArgs event_arg)
    {
        m_data.userId = event_arg.Data;
        m_data.gameCategory = "Bullet";
        m_data.score = 0;
    }

    public void Send()
    {
        m_web_socket.Send(JsonUtility.ToJson(m_data));
    }
}