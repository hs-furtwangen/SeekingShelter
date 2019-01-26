using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyMovement : MonoBehaviour
{
    Rigidbody2D rb;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");

        if (GameController.Instance.CanMove)
        {
            rb.AddForce(Vector2.right * Input.GetAxis("Horizontal") * 10);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }


        //anim.SetFloat("movement", moveHorizontal);
    }
}
