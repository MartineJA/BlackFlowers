using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb2D;
    private Vector2 direction;
    private Animator animator;

    bool isJumping = false;
    private float jumpNb;


    [SerializeField]
    private float moveSpeed;
 
    [SerializeField]
    private float jumpHeight = 150f;

    [SerializeField]
    private int maxJump = 2;

    [SerializeField]
    private float fall = 3f;

    [Header("Related Gameobjects")]
    [SerializeField]
    private GameObject graphics;

    // Start is called before the first frame update

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = graphics.GetComponent<Animator>();
        
       
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal") * moveSpeed;

        if (Input.GetButtonDown("Jump") && jumpNb<maxJump)
        {
            isJumping = true;
            animator.SetTrigger("Jump");
        }

        if (direction.x < 0f)
        {
            graphics.transform.localScale = new Vector3(-1, 1, 1);

        }
        else if (direction.x > 0f)
        {
            graphics.transform.localScale = new Vector3(1, 1, 1);
        }


        animator.SetFloat("SpeedX", Mathf.Abs(direction.x));
        animator.SetFloat("SpeedY", rb2D.velocity.y);

    }

    private void FixedUpdate()
    {
        direction.y = rb2D.velocity.y;


        if (isJumping)
        {
            direction.y = jumpHeight * Time.fixedDeltaTime;
            isJumping = false;
            jumpNb++;
        }

        if(rb2D.velocity.y < 0)
        {
            rb2D.gravityScale = fall;
        }
        else
        {
            rb2D.gravityScale = 1f;
        }
        rb2D.velocity = direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Plateforme"))
        {
            jumpNb = 0;
        }
    }

}
