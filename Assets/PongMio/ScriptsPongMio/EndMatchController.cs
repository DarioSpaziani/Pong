using PongMio;
using UnityEngine;

public class EndMatchController : MonoBehaviour {
   private GameManager gameManager;

   private void Start() {
      gameManager = FindObjectOfType<GameManager>();
   }

   private void Update() {
      if (gameManager.pointPlayerSub.point1 >= 3) {
         endMatch();
      }
   }

   private void endMatch() {
      GameManager.Instance.endMatch();
   }
}
