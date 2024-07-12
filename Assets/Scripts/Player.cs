using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyCode upKey = KeyCode.W;
    public KeyCode downKey = KeyCode.S;
    public float speed = 5f; // Adjust the speed to your liking
    public float maxY = 4.5f; // Set the maximum y-position
    public float minY = -4.5f; // Set the minimum y-position

    void Update()
    {
        // Get input from the player
        float input = 0f;

        if (Input.GetKey(upKey))
        {
            input = 1f;
        }
        else if (Input.GetKey(downKey))
        {
            input = -1f;
        }

        // Calculate the new position of the paddle
        float newY = transform.position.y + input * speed * Time.deltaTime;

        // Clamp the position to stay within the playable area
        newY = Mathf.Clamp(newY, minY, maxY);

        // Update the paddle's position
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}