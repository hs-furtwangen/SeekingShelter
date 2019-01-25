using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyMovement : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.Instance.CanMove)
        {
            rb.AddForce(Vector2.right * Input.GetAxis("Horizontal") * 10);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
