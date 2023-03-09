using UnityEngine;

namespace LezioneBasi 
{
	public class ManagerExample : MonoBehaviour 
	{ 
		//esempio su come da gameObject fare una chiamata al manager
		private void Start() {
			LevelManager.Instance.SayHi();
		}
	}
}
