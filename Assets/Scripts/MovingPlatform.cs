using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 targetPosition;
    public Vector3 basePosition;
    public int offset = 25;
    public float speed = 20f;
    public bool isMoving = false;
    void Start()
    {
        basePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetPosition == transform.position)
        {
            if (transform.position.x > basePosition.x)
            {
                targetPosition = new Vector3(transform.position.x - offset, transform.position.y, transform.position.z);

            }
            else
            {
                targetPosition = new Vector3(transform.position.x + offset, transform.position.y, transform.position.z);
            }

        }


        transform.position = Vector3.MoveTowards(transform.position, (targetPosition), speed * Time.deltaTime);



    }
}
