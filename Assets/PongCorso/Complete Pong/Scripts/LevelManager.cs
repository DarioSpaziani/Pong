using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CompletePong
{
    public class LevelManager : MonoBehaviour{

        //Simplified Singleton Instance
        public static LevelManager Instance;

        public GameObject startPanel;
        public GameObject gameOverPanel;
        public Text countText;
        public Text scoreText;
        public BallController ball;


        //Simplified Singleton
        private void Awake(){
            if (Instance == null)
                Instance = this;
            else if (Instance != this)
                Destroy(gameObject);
        }


        public void startGame(){
            Time.timeScale = 1;
            StartCoroutine(countDown());
        }

        private IEnumerator countDown(){

            for (int i = 3; i > 0; i--){
                countText.text = i.ToString();
                yield return new WaitForSeconds(1);
            }

            countText.text = "GO!";
            yield return new WaitForSeconds(1);

            startPanel.SetActive(false);

            launch();
        }

        private void launch(){
            ball.launchBall();
        }

        public void gameOver(){
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }

        public void updateScoreUI(int score){
            scoreText.text = score.ToString();
        }

        public void reloadLevel(){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}