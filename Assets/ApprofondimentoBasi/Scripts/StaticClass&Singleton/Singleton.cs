using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour 
{
	private static T instance; //si crea una variabile statica di tipo generico come la classe e verrà esposta all'esterno tramite il suo getter.
	private static object _lock = new object();
	private static bool ApplicationIsQuitting = false;

	public static T Instance {
		get {
			if (ApplicationIsQuitting) {
				return null;
			}

			lock (_lock) {
				if (instance == null) {
					instance = (T)FindObjectOfType(typeof(T));

					if (FindObjectsOfType(typeof(T)).Length > 1) {
						return instance;
					}

					if (instance == null) {
						GameObject singleton = new GameObject();
						instance = singleton.AddComponent<T>();
						singleton.name = "(singleton)" + typeof(T);

						DontDestroyOnLoad(singleton);
					}
				}
				return instance;
			}
		}
	}

	public void OnDestroy() {
		ApplicationIsQuitting = true;
	}
}