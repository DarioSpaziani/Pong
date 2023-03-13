using PongMio;
using UnityEngine;

public class RematchSubscriber : MonoBehaviour {
    private GameManager gameManager;
    public void Rematch() {
        gameManager.scorePanel.SetActive(false);
        gameManager.winnerPanel.SetActive(false);
        gameManager.rematchPanel.SetActive(true);
        GameManager.Instance.Rematch();
    }
}
