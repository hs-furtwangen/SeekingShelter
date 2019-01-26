using UnityEngine;

public class DummyMovement : MonoBehaviour
{
    Rigidbody2D rb;

    private Animator anim;
    private SpriteRenderer spriteRend;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        if (GameController.Instance.GameStates["CanMove"])

        {
            rb.AddForce(Vector2.right * Input.GetAxis("Horizontal") * 10);
        }
        else
        {
            rb.velocity = Vector2.zero;
            rb.angularDrag = 0f;
        }
        anim.SetFloat("movement", moveHorizontal);

        if (Input.GetKeyDown("c"))
        {
            anim.SetBool("isCrouching", true);
        }
        if (Input.GetKeyDown("v"))
        {
            anim.SetBool("isCrouching", false);
        }
        if (Input.GetKeyDown("x"))
        {
            anim.SetBool("isCaught", true);
        }
    }

}
