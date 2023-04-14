using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform character;

    public List<Transform> availableCharacters;
    public int whichCharacter;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    public LayerMask groundLayer;
    private BoxCollider2D coll;
    private Rigidbody2D rb;
    private bool isGrounded;


    void Start()
    {
        if (character == null && availableCharacters.Count > 1)
        {
            character = availableCharacters[0];
        }
        SwitchBodies();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        //body2.GetComponent<PlayerController>().enabled = false;

    }

    void FixedUpdate()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        isGrounded = Physics2D.IsTouchingLayers(coll, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            //rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (whichCharacter == availableCharacters.Count - 1)
            {
                whichCharacter = 0;

            }
            else
            {
                whichCharacter += 1;

            }
            SwitchBodies();

        }
    }


    void SwitchBodies()
    {
        character = availableCharacters[whichCharacter];
        character.GetComponent<PlayerController>().enabled = true;
        for (int i = 0; i < availableCharacters.Count; i++)
        {
            if (availableCharacters[i] != character)
            {
                availableCharacters[i].GetComponent<PlayerController>().enabled = false;
            }

        }

    }
}
