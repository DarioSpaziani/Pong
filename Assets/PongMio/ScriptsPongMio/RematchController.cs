using PongMio;
using UnityEngine;

public class RematchController : MonoBehaviour {
    
    public void Rematch() {
        GameManager.Instance.Rematch();
    }
}
