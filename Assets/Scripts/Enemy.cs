using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 direction;
    public Vector3 rotation;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    void FixedUpdate()
    {
        transform.Translate(direction.normalized * speed);
        transform.Rotate(rotation * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        rb.gravityScale = 1f;

        if (col.gameObject.tag == "Player")
        {
            PlayerMovement player = col.gameObject.GetComponent<PlayerMovement>();
            player.Kill();
        }
    }

    

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
