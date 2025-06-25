using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;

    public static T Instance
    {

        get
        {
            if (!_instance)
            {
                _instance = (T)FindFirstObjectByType(typeof(T));
                if (!_instance)
                    SetupInstance();
            }

            return _instance;
        }
    }

    private void Awake() => RemoveDuplicates();

    private static void SetupInstance()
    {
        _instance = (T) FindFirstObjectByType(typeof(T));

        if (!_instance)
        {
            GameObject gameObject = new GameObject();
            gameObject.name = typeof(T).Name;
            _instance = gameObject.AddComponent<T>();
                
            //Maybe not needed
            //DontDestroyOnLoad(gameObject);
        }
            
    }

    private void RemoveDuplicates()
    {
        if (!_instance)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}