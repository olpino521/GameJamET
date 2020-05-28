using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerActions : MonoBehaviour
{
    [SerializeField] Menu menuRef;
    [SerializeField]
    private float forward = 8f;
    [SerializeField]
    private float jump = 8f;

    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        rb.AddForce(new Vector2(0f, jump),ForceMode2D.Impulse);
    }

    public void MoveForward()
    {
        rb.AddForce(new Vector2(forward, 0f), ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Death"))
        {
            menuRef.GameOver("You Lose");
        }
        else if (collision.CompareTag("Win"))
        {
            menuRef.GameOver("You Win");
        }
    }
}
