using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCriteriaPlayer : MonoBehaviour
{
    public Collider2D objectCollider;
    public Collider2D anotherCollider;
    // Start is called before the first frame update
    void Start()
    {
        objectCollider = GetComponent<Collider2D>();
        anotherCollider = GameObject.FindGameObjectWithTag("Nightmare").GetComponent<Collider2D>();
    }



    private void Update()
    {
        if (objectCollider.IsTouching(anotherCollider))
        {
            Debug.Log("YOU WON!!!");
        }
    }
}
