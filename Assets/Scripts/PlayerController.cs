using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Transform character;

	public List<Transform> availableCharacters;
	public List<GameObject> availableCameras;

	public const float maxHorizontalVelocity = 8f;
	public const float maxVerticalVelocity = 40f;
	public const float acceleration = 0.1f;
	public const float gravity = 0.05f;

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
		rb.isKinematic = true;
	}

	void Update()
	{
		float move = Input.GetAxisRaw("Horizontal");

		Vector2 position = transform.position;
		Vector2 adjustedColliderSize = new Vector2(coll.bounds.size.x, coll.bounds.size.y); // Adjust the collider size for the BoxCast

		Vector2 direction = Vector2.down;
		float distance = 0.1f;
		isGrounded = Physics2D.BoxCast(position, adjustedColliderSize, 0f, direction, distance - 0.03f, groundLayer);

		bool isBlockedLeft = Physics2D.BoxCast(position, adjustedColliderSize, 0f, Vector2.left, distance, groundLayer);
		bool isBlockedRight = Physics2D.BoxCast(position, adjustedColliderSize, 0f, Vector2.right, distance, groundLayer);

		bool isBlockedTop = Physics2D.BoxCast(position, adjustedColliderSize, 0f, Vector2.up, distance, groundLayer);


		if (isBlockedTop) //starts falling after hitting roof
		{
			verticalVelocity = 0 - gravity * 10;
		}
		else if (!isGrounded) //continues falling if isnt on ground
		{
			verticalVelocity -= gravity;
		}
		else if (isGrounded) //ground is hit, doesnt move vertically
		{
			verticalVelocity = 0;
		}




		if (horizontalVelocity < 0) //horizontalvelocity cant be below 0
		{
			horizontalVelocity = 0;
		}

		if (horizontalVelocity <= 0 && move != movingDirection) //   
		{
			movingDirection = move;
		}

		if (move == 0 && horizontalVelocity > 0)
		{
			horizontalVelocity -= acceleration / 2;
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
			horizontalVelocity -= acceleration / 2;
		}

		if (movingDirection < 0 && isBlockedLeft)
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
		Vector3 newPosition = transform.position + new Vector3(movingDirection * horizontalVelocity * Time.deltaTime, verticalVelocity * Time.deltaTime, 0);

		// Check for collision at the new position using BoxCast
		bool wouldCollide = Physics2D.BoxCast(newPosition, adjustedColliderSize, 0f, Vector2.zero, 0f, groundLayer);

		// Update the position only if there's no collision
		if (!wouldCollide)
		{
			transform.position = newPosition;
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