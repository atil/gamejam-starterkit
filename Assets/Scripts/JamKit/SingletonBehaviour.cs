using UnityEngine;

public abstract class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();

                if (_instance == null)
                {
                    GameObject go = new GameObject($"Singleton{typeof(T).Name}");
                    _instance = go.GetComponent<T>();
                }
                
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }
}