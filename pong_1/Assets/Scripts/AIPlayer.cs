using UnityEngine;

public class AIPlayer : MonoBehaviour
{
    private Paddle paddle; // Reference to the player paddle script

    public float difficultyFactor = 1.0f; // Adjust this based on difficulty settings
    void Start()
    {
        // Find and store the reference to the player paddle
        FindPlayerPaddle();

        // Disable the player script if it exists in the parent object
        DisableIfPlayerExists();
    }

    void FixedUpdate()
    {
        // Track the ball's Y position for AI movement
        float targetY = Ball.Instance.transform.position.y;

        // Adjust the paddle's Y position based on the ball's position with some randomness
        float yOffset = Random.Range(-0.5f, 0.5f) * difficultyFactor;
        float newY = Mathf.Lerp(transform.position.y, targetY + yOffset, Time.deltaTime * difficultyFactor);

        // Apply the new Y position to the AI-controlled paddle
        transform.position = new Vector2(transform.position.x, newY);
    }

    // Finds the player paddle script in the parent object
    void FindPlayerPaddle()
    {
        paddle = GetComponentInParent<Paddle>();
    }

    // Disables the player script if it exists in the parent object
    void DisableIfPlayerExists()
    {
        Player player = GetComponentInParent<Player>();
        if (player != null)
        {
            player.enabled = false;
        }
    }
}