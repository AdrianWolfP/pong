using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PongGame : MonoBehaviour
{
    public int winningScore = 11;
    public TMP_Text victoryMessage;
    public TMP_Text player1ScoreText;
    public TMP_Text player2ScoreText;

    private int player1Score = 0;
    private int player2Score = 0;

    void Start()
    {
        // Initialize UI text components
        victoryMessage.text = "";
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        // Update the UI with current scores
        player1ScoreText.text = "Player 1: " + player1Score.ToString();
        player2ScoreText.text = "Player 2: " + player2Score.ToString();
    }

    void PlayerScored(int playerNumber)
    {
        if (playerNumber == 1)
        {
            player1Score++;
        }
        else if (playerNumber == 2)
        {
            player2Score++;
        }

        UpdateScoreUI();

        // Check if either player has reached the winning score
        if (player1Score >= winningScore || player2Score >= winningScore)
        {
            DeclareWinner();
        }
    }

    void DeclareWinner()
    {
        // Stop the game (pause or disable player controls)

        // Display victory and defeat messages
        if (player1Score >= winningScore)
        {
            victoryMessage.text = "Player 1 Wins!";
        }
        else
        {
            victoryMessage.text = "Player 2 Wins!";
        }
    }

    // Add your other game logic, input handling, and ball movement here

    // Example usage (call this method when a player scores a point)
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Determine which player scored based on the ball's position
            int playerNumber = (collision.gameObject.transform.position.x > 0) ? 1 : 2;
            PlayerScored(playerNumber);
        }
    }
}