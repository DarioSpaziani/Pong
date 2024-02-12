using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour 
{
	private static T instance;
	public static T Instance => instance;

    public virtual void Awake()
    {
        if(instance == null)
		{
			instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}