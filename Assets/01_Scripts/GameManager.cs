using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{

    #region FIELDS

    public static GameManager Instance { get; private set; }

    [Header("Ref")]
    private WallGoal WallGoal;
    public GameObject canvasScore;
    public GameObject canvasWinner;
    public GameObject canvasRematch;

    [Header("Texts")]
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI winnerText;
    public TextMeshProUGUI scorePlayer1Text;
    public TextMeshProUGUI scorePlayer2Text;
    public TextMeshProUGUI countStartText;

    [Header("Variables")]
    public Ball ball;
    [SerializeField] private int pointPlayerOne;
    [SerializeField] private int pointPlayerTwo;
    [SerializeField] private int maxScore = 3;
    public float timer;
    public int countdown = 3;

    [Header("Paddles")]
    public Transform player1;
    public Transform player2;

    private Vector3 ballStartPos;
    private Vector3 p1StartPos;
    private Vector3 p2StartPos;

    #endregion

    #region UNITY_CALLS

    private void OnEnable()
    {
        if (WallGoal != null) WallGoal.OnGoal += HandleGoal;
    }

    private void OnDisable()
    {
        if (WallGoal != null) WallGoal.OnGoal -= HandleGoal;
    }

    private void HandleGoal(int idPlayer)
    {
        AddPoint(idPlayer);
        StartCoroutine(ResetRoundCoroutine());
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        ballStartPos = ball.transform.position;
        if (player1 != null) p1StartPos = player1.position;
        if (player2 != null) p2StartPos = player2.position;

        if (WallGoal == null) WallGoal = FindObjectOfType<WallGoal>();

        if (canvasScore == null)
            canvasScore = GameObject.Find("CanvasScore");

        if (canvasWinner == null)
            canvasWinner = GameObject.Find("CanvasWinner");

        if (canvasRematch == null)
            canvasRematch = GameObject.Find("CanvasRematch");

        if (ball == null) ball = FindObjectOfType<Ball>();
    }

    private void Start()
    {
        canvasWinner.SetActive(false);
        canvasScore.SetActive(true);
        canvasRematch.SetActive(false);

        StartCoroutine(CountdownStartMatch());
    }

    private void Update()
    {
        if (pointPlayerOne >= maxScore)
        {
            canvasWinner.SetActive(true);
            winnerText.text = "Player 1 Win!";
            winnerText.color = Color.blue;
            EndMatch();
        }
        if (pointPlayerTwo >= maxScore)
        {
            canvasWinner.SetActive(true);
            winnerText.text = "Player 2 Win!";
            winnerText.color = Color.red;
            EndMatch();
        }
    }

    private IEnumerator ResetRoundCoroutine()
    {
        ball.rb.velocity = Vector3.zero;
        ball.rb.angularVelocity = Vector3.zero;

        ball.transform.position = ballStartPos;

        if (player1 != null) player1.position = p1StartPos;
        if (player2 != null) player2.position = p2StartPos;

        yield return null;

        ball.LaunchBall();
    }

    public void AddPoint(int score)
    {
        if (score == 1) pointPlayerOne++;
        else if (score == 2) pointPlayerTwo++;
        scorePlayer1Text.text = "Player 1 : " + pointPlayerOne.ToString();
        scorePlayer2Text.text = "Player 2: " + pointPlayerTwo.ToString();
    }

    public void EndMatch()
    {
        //aggiunger ciclo di colori per la scritta game over
        finalScoreText.text = pointPlayerOne + " - " + pointPlayerTwo;

        ball.rb.velocity = Vector3.zero;

        timer += Time.time;

        if (timer > 3)
        {
            canvasRematch.SetActive(true);
        }
    }

    private IEnumerator CountdownStartMatch()
    {
        for (int i = countdown; i > 0; i--)
        {
            countdown--;
            countStartText.text = i.ToString();
            yield return new WaitForSeconds(1f);

        }
        countStartText.text = "START!";
        yield return new WaitForSeconds(1f);

        countStartText.enabled = false;

        canvasScore.SetActive(true);

        canvasRematch.SetActive(false);
        canvasWinner.SetActive(false);

        ball.LaunchBall();
    }

    public void Rematch()
    {
        pointPlayerOne = 0;
        pointPlayerTwo = 0;
        timer = 0;
        countdown = 3;

        SceneManager.LoadScene(0);
    }
    #endregion
}