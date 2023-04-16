using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FallingPlatform : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector3 basePosition;
    public float time_until_fall = 3;
    public int speed = 10;
    private bool isFalling = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        basePosition = transform.position;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Nightmare") || col.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("collided");
            StartCoroutine(DropPlatform());
        }
    }

    IEnumerator DropPlatform()
    {
        yield return new WaitForSeconds(time_until_fall);
        if (!isFalling)
        {
            isFalling = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    void Update()
    {
        if (rb.velocity.y == 0 && transform.position != basePosition && isFalling)
        {
            StartCoroutine(RaisePlatform());
        }
    }

    IEnumerator RaisePlatform()
    {
        isFalling = false;
        rb.bodyType = RigidbodyType2D.Kinematic;
        while (transform.position != basePosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, basePosition, speed * Time.deltaTime);
            yield return null;
        }
        rb.velocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Static;
    }
}
