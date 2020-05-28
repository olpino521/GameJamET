using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerActions : MonoBehaviour
{
    [SerializeField]
    private float forward = 8f;
    [SerializeField]
    private float jump = 8f;

    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Jump()
    {
        rb.AddForce(new Vector3(0f, jump + 5f, 0f), ForceMode.Impulse);
    }

    public void MoveForward()
    {
        rb.AddForce(new Vector3(forward + 5f, 0f, 0f), ForceMode.Impulse);
    }
}
