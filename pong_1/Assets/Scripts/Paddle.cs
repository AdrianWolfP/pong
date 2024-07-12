using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 10f;
    private Vector2 paddleSize;

    private float screenHeight;

    void Start()
    {
        paddleSize = GetComponent<BoxCollider2D>().bounds.size;
        screenHeight = Camera.main.orthographicSize;
    }

    void Update()
    {
        float move = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Vector2 paddlePos = transform.localPosition;
        paddlePos.y += move;

        transform.localPosition = paddlePos;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            collision.gameObject.GetComponent<Ball>().LaunchBall();
        }
    }
}