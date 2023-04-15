using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 12f;
    RaycastHit2D hitRight;
    RaycastHit2D hitLeft;
    public LayerMask groundLayer;
    private BoxCollider2D coll;
    private Rigidbody2D rb;
    private bool isGrounded;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);
        //RaycastHit2D hitRight = Physics2D.Raycast(coll.bounds.center, Vector2.right, coll.bounds.extents.x + addition);
        hitRight = (Physics2D.Raycast(transform.position, transform.right, .65f, (LayerMask.GetMask("Ground"))));
        //Debug.DrawRay(transform.position, transform.right, Color.black);
        hitLeft = (Physics2D.Raycast(transform.position, -transform.right, .65f, (LayerMask.GetMask("Ground"))));
        //Debug.DrawRay(transform.position, -transform.right, Color.black);
        //RaycastHit2D hitLeft = Physics2D.Raycast(coll.bounds.center, Vector2.left, (-coll.bounds.extents.x) + addition);
        //Debug.Log(hitLeft.collider);
        //Debug.Log(hitRight.collider);
        if (hitRight.collider == null && hitLeft.collider == null)
        {
            isGrounded = Physics2D.IsTouchingLayers(coll, groundLayer);
        }
        else
        {
            isGrounded = false;

        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

    }

}