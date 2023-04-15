using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform character;

    public List<Transform> availableCharacters;
    public List<GameObject> availableCameras;

    public const float maxVelocity = 8f;
    public const float acceleration = 0.3f;
	public float velocity = 0;
    public float movingDirection = 0;

	public int whichCharacter;
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
            availableCameras[0].SetActive(true);
        }
        SwitchBodies();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();

    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

        if (move == 0 && velocity > 0) 
        {
			velocity -= acceleration / 3;
		}
        else if(move == movingDirection) 
        {
            if (velocity < maxVelocity)
            {
                velocity += acceleration;
            }
        }
        else if(move!=movingDirection && velocity>0)
        {
            velocity -= acceleration/3;
        }
        else if(velocity<=0)
        {
            movingDirection = move;
        }
        


        rb.velocity = new Vector2(movingDirection * velocity, rb.velocity.y);

		Vector2 position = transform.position;
		Vector2 direction = Vector2.down;
		float distance = coll.bounds.extents.y + 0.1f;
		isGrounded = Physics2D.Raycast(position, direction, distance, groundLayer);

		if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
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
        availableCameras[whichCharacter].SetActive(true);
        for (int i = 0; i < availableCharacters.Count; i++)
        {
            if (availableCharacters[i] != character)
            {
                availableCharacters[i].GetComponent<PlayerController>().enabled = false;
                availableCameras[i].SetActive(false);
            }

        }

    }
}
