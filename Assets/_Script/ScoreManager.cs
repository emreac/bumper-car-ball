using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] private GameObject winUI;
    [SerializeField] private GameObject loseUI;
    private int player1Score = 0;
    private int player2Score = 0;

    [SerializeField] private TMP_Text player1ScoreText;
    [SerializeField] private TMP_Text player2ScoreText;

    [SerializeField] private int winScore = 3;

    // References to the player GameObjects and ball
    public GameObject player1;
    public GameObject player2;
    public GameObject ball;

    private Vector3 player1StartPosition;
    private Vector3 player2StartPosition;
    private Vector3 ballStartPosition;

    private Quaternion player1StartRotation;
    private Quaternion player2StartRotation;
    private Quaternion ballStartRotation;

    private Rigidbody ballRb;

    private void Start()
    {
        // Store the initial positions and rotations
        player1StartPosition = player1.transform.position;
        player1StartRotation = player1.transform.rotation;

        player2StartPosition = player2.transform.position;
        player2StartRotation = player2.transform.rotation;

        ballStartPosition = ball.transform.position;
        ballStartRotation = ball.transform.rotation;

        ballRb = ball.GetComponent<Rigidbody>();

        UpdateScoreUI();
    }

    public void Player1Scored()
    {
        player1Score++;
        UpdateScoreUI();
        CheckWinCondition();
        StartCoroutine(ResetPositionsWithDelay(1.5f)); // 1.5 second delay before resetting positions
    }

    public void Player2Scored()
    {
        player2Score++;
        UpdateScoreUI();
        CheckWinCondition();
        StartCoroutine(ResetPositionsWithDelay(1.5f)); // 1.5 second delay before resetting positions
    }

    private void UpdateScoreUI()
    {
        player1ScoreText.text = player1Score.ToString();
        player2ScoreText.text = player2Score.ToString();
    }

    private void CheckWinCondition()
    {
        if (player1Score >= winScore)
        {
            EndGame("Player 1");
            winUI.SetActive(true);
        }
        else if (player2Score >= winScore)
        {
            EndGame("Player 2");
            loseUI.SetActive(true);
        }
    }

    private void EndGame(string winner)
    {
        // Start a coroutine to delay the game stop until after the UI is displayed
        StartCoroutine(EndGameRoutine(winner));
    }
    private IEnumerator EndGameRoutine(string winner)
    {
        // Show the win message before stopping the game
        winUI.SetActive(true);
        //winMessage.GetComponent<TMP_Text>().text = winner + " Wins!";

        // Wait for a short duration (e.g., 0.5 seconds) before stopping the game
        yield return new WaitForSecondsRealtime(0.5f);

        // Now stop the game
        Time.timeScale = 0f;

        //Debug.Log(winner + " wins the game!");
    }

    // Coroutine to reset positions with a delay
    private IEnumerator ResetPositionsWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Reset player 1
        player1.transform.position = player1StartPosition;
        player1.transform.rotation = player1StartRotation;

        // Reset player 2
        player2.transform.position = player2StartPosition;
        player2.transform.rotation = player2StartRotation;

        // Reset ball position and stop its velocity
        ball.transform.position = ballStartPosition;
        ball.transform.rotation = ballStartRotation;
        ballRb.velocity = Vector3.zero;
        ballRb.angularVelocity = Vector3.zero;

    }



    public void RestartGame()
    {
        // Unfreeze the game
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        /*
        // Reset scores and UI
        player1Score = 0;
        player2Score = 0;
        UpdateScoreUI();

        // Hide the win message
        winUI.SetActive(false);
        loseUI.SetActive(false);
        // Optionally, reset positions
        ResetPositions();
        */
    }


    private void ResetPositions()
    {
        player1.transform.position = player1StartPosition;
        player1.transform.rotation = player1StartRotation;

        player2.transform.position = player2StartPosition;
        player2.transform.rotation = player2StartRotation;

        ball.transform.position = ballStartPosition;
        ball.transform.rotation = ballStartRotation;

        ballRb.velocity = Vector3.zero;
        ballRb.angularVelocity = Vector3.zero;
    }
}
