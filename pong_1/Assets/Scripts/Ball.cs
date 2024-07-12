using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    public static Ball Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance!= this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    public void LaunchBall()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(x, y) * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            float y = hitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.y);
            Vector2 dir = new Vector2(rb.velocity.x, y).normalized;
            rb.velocity = dir * speed;
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 paddlePos, float paddleHeight)
    {
        return (ballPos.y - paddlePos.y) / paddleHeight;
    }

    public void ResetBall()
    {
        transform.position = Vector3.zero;
        LaunchBall();
    }
}