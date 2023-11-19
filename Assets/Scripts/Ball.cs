using UnityEngine;

public class Ball : MonoBehaviour
{
    public float moveForce;
    public float jumpSpeed;
    Rigidbody2D rb;
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var hor = Input.GetAxisRaw("Horizontal");
        rb.AddForce(new Vector2(hor, 0) * moveForce);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity += Vector2.up * jumpSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = true;

        if (other.gameObject.CompareTag("Enemy"))
        {
            FindObjectOfType<GameManager>().Lose();
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        isGrounded = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Teleporter")
        {
            FindObjectOfType<GameManager>().Win();
        }
    }
}