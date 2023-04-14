using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTrapDoor : MonoBehaviour
{
    public Transform Trapdoor;
    public Collider2D coll;
    public Collider2D anotherCollider;
    public float speed;
    public bool isMoving = false;
    public Vector3 targetPosition = new Vector3(-51f, -6.762f, -0.15f);

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        anotherCollider = GameObject.FindGameObjectWithTag("Nightmare").GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (coll.IsTouching(anotherCollider) && Input.GetKeyDown(KeyCode.E))
        {
            isMoving = true;

        }
        if (isMoving)
        {
            Trapdoor.position = Vector3.MoveTowards(Trapdoor.position, (targetPosition), speed * Time.deltaTime);

        }

    }
}
