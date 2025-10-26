using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private float wallJumpPower = 16f;
    private bool isTouchingWall;
    private bool isWallJumping;
    private float wallJumpDirection;
    private float wallJumpTime = 0.2f;

    private float horizontal;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;

    private bool isFacingRight = true;
    private bool canDash = true;
    private bool canDashTime = true;
    private bool isDashing;
    [SerializeField] private float dashingPower = 24f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashingCooldown = 0.5f;
    [SerializeField] private float dashingCooldown = 0.5f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;

    void Update()
    {
        if (isDashing)
            return;

        horizontal = Input.GetAxisRaw("Horizontal");

        // Wall check
        isTouchingWall = Physics2D.OverlapCapsule(wallCheck.position, new Vector2(1.4f, 0.2f), CapsuleDirection2D.Horizontal, 0f, wallLayer);
        if (IsGrounded())
        { 
            canDash = true;
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

            }
            else if (isTouchingWall)
            {
                isWallJumping = true;
                wallJumpDirection = isFacingRight ? -1 : 1;
                rb.velocity = new Vector2(wallJumpDirection * speed, wallJumpPower);
                Invoke(nameof(StopWallJumping), wallJumpTime);
            }
        }

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }

            if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && canDashTime)
            {
                StartCoroutine(Dash());
            }

            Flip();
        }

    private void FixedUpdate()
    {
        if (isDashing || isWallJumping)
            return;

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if ((isFacingRight && horizontal < 0f) || (!isFacingRight && horizontal > 0f))
        {
            isFacingRight = !isFacingRight;
            Vector3 localscale = transform.localScale;
            localscale.x *= -1f;
            transform.localScale = localscale;
        }
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
    }

    private IEnumerator Dash()
    {
        canDash = false;
        canDashTime = false;
        isDashing = true;
        tr.emitting = true;

        float originalGravityScale = rb.gravityScale;
        rb.gravityScale = 0f;

        // Dash in the direction the player is facing
        rb.velocity = new Vector2((isFacingRight ? 1 : -1) * dashingPower, 0f);

        yield return new WaitForSeconds(dashingTime);

        rb.gravityScale = originalGravityScale;
        isDashing = false;
        tr.emitting = false;

        yield return new WaitForSeconds(dashingCooldown);
        canDashTime = true;
    }
}
}