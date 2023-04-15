using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Transform character;

	public List<Transform> availableCharacters;
	public List<GameObject> availableCameras;

<<<<<<< Updated upstream
	public const float maxHorizontalVelocity = 8f;
	public const float maxVerticalVelocity = 30f;
	public const float acceleration = 0.1f;
	public const float gravity = 0.2f;


	public float horizontalVelocity = 0;
	public float verticalVelocity = 0;
	public float movingDirection = 0;

	public int whichCharacter;
	public float jumpForce = 40f; 

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
		rb.isKinematic = true; // Disable physics for the Rigidbody2D
	}

	void Update()
	{
		float move = Input.GetAxisRaw("Horizontal");

		Vector2 position = transform.position;
		Vector2 direction = Vector2.down;
		float distance = coll.bounds.extents.y + 0.1f;
		isGrounded = Physics2D.Raycast(position, direction, distance, groundLayer);

		bool isBlockedLeft=Physics2D.Raycast(position,Vector2.left,coll.bounds.extents.x-0.1f,groundLayer);
		bool isBlockedRight = Physics2D.Raycast(position, Vector2.right, coll.bounds.extents.x + 0.1f, groundLayer);
		bool isBlockedTop = Physics2D.Raycast(position, Vector2.up, coll.bounds.extents.y - 0.1f, groundLayer);

		if (!isGrounded)
		{
			verticalVelocity -=gravity;
		}
		else if (isGrounded)
		{
			verticalVelocity = 0;
		}
		else if (isBlockedTop)
		{
			verticalVelocity = 0;
		}


		if (horizontalVelocity < 0)
		{
			horizontalVelocity = 0;
		}

		if (horizontalVelocity <= 0 && move != movingDirection)
		{
			movingDirection = move;
		}

		if (move == 0 && horizontalVelocity > 0)
		{
			horizontalVelocity -= acceleration / 3;
		}
		else if (move == movingDirection)
		{
			if (horizontalVelocity < maxHorizontalVelocity)
			{
				horizontalVelocity += acceleration;
			}
		}
		else if (move != movingDirection && horizontalVelocity > 0)
		{
			horizontalVelocity -= acceleration / 3;
		}

		if(movingDirection<0 && isBlockedLeft)
		{
			horizontalVelocity = 0;
		}

		if (movingDirection > 0 && isBlockedRight)
		{
			horizontalVelocity = 0;
		}


		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			// Update vertical movement using transform instead of Rigidbody2D's velocity
			verticalVelocity += jumpForce; 
		}

		// Update horizontal movement using transform instead of Rigidbody2D's velocity
		transform.position += new Vector3(movingDirection * horizontalVelocity * Time.deltaTime, verticalVelocity * Time.deltaTime, 0);

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
