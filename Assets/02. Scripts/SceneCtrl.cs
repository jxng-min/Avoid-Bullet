using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCtrl : MonoBehaviour
{
    [SerializeField]
    private string m_scene_name;

    public void SwitchScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(m_scene_name);
    }
}