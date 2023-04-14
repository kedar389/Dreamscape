using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector3 basePosition;
    public int speed = 10;
    private bool donecollision;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        basePosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player") || col.gameObject.tag.Equals("Nightmare"))
        {
            Invoke("DropPlatform", 0.5f);
            //Destroy(gameObject, 2f);

        }


    }


    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player") || other.gameObject.tag.Equals("Nightmare"))
        {
            donecollision = false;

        }

    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player") || other.gameObject.tag.Equals("Nightmare"))
        {
            donecollision = true;

        }

    }
    void Update()
    {
        if (rb.velocity.y == 0 && transform.position != basePosition)
        {
            if (donecollision)
            {
                Invoke("RaisePlatform", 5f);
            }
        }



    }
    // Update is called once per frame
    void DropPlatform()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;

    }

    void RaisePlatform()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
        transform.position = Vector3.MoveTowards(transform.position, (basePosition), speed * Time.deltaTime);

    }
}
