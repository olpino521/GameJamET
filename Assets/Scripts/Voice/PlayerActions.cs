using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField]
    private float move = 1f;

    public void Jump()
    {
        transform.position += Vector3.up * move;
    }
    
    public void MoveLeft()
    {
        transform.position += Vector3.left * move;
    }
}
