using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    // Start is called before the first frame update
    private float horizontal;

   [SerializeField]   private float jumpingPower = 16f;
    private bool isFacingRight = true;

    private bool doubleJump;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private void Awake()
    {
        
    }
    private void Start()
    {
        groundCheck = GameObject.Find("CheckGround").transform;
    }
    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (IsGrounded() && !Input.GetButton("Jump") )
        {
            doubleJump = false;
            AnimationPlayer.instance.IsDown = true;
        }

        if (Input.GetButtonDown("Jump") || Input.GetKey(KeyCode.UpArrow))
        {
            if (IsGrounded() || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

                doubleJump = !doubleJump;
                AnimationPlayer.instance.IsDown = false;
            }
        }

        if ((Input.GetButtonUp("Jump")  && rb.velocity.y > 0f) || (Input.GetKey(KeyCode.UpArrow) && rb.velocity.y > 0f))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            AnimationPlayer.instance.IsDown = false;
        }

        Flip();
    }


    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

    }
}
