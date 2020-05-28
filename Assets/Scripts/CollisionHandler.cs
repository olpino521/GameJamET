using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject playerRef;
    [SerializeField] Menu menuHandler;
    [SerializeField] string objectName;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (objectName.Equals("Death"))
        {
            menuHandler.GameOver("You Lose");
        }
        else if (objectName.Equals("Win"))
        {
            menuHandler.GameOver("You Win");
        }
    }
}
