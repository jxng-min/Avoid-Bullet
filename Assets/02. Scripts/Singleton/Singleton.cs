using UnityEngine;

namespace _Singleton
{
    public class Singleton<T> : MonoBehaviour where T: Component
    {
        public static T m_instance;

        public static T Instance
        {
            get
            {
                if(m_instance == null)
                {
                    m_instance = FindObjectOfType<T>();

                    if(m_instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.name = typeof(T).ToString();
                        m_instance = obj.AddComponent<T>();
                    }
                }

                return m_instance;
            }
        }

        public virtual void Awake()
        {
            if(m_instance == null)
            {
                m_instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else
                Destroy(gameObject);
        }
    }
}