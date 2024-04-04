using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCtrl : MonoBehaviour
{
    [SerializeField]
    private string m_scene_name;
    public void SceneChange()
    {
        SceneManager.LoadScene(m_scene_name);
    }

    public void SettingOn()
    {
        GameManager.game_state = GameManager.GameState.SETTING;
    }

    public void SettingOff()
    {
        GameManager.game_state = GameManager.GameState.PLAYING;
    }
}
