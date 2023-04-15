using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingFuck : MonoBehaviour
{
    public DetectionZone attackZone; // Add missing semicolon

    Animator animator; // Add missing semicolon

    private bool _hasTarget = false;
    public bool HasTarget
    {
        get { return _hasTarget; }
        private set
        {
            _hasTarget = value; // Correct variable name from "valuel" to "value"
            animator.SetBool("hasTarget", value);

        }
    } 

    void Update()
    {
        HasTarget = attackZone.detectedColliders.Count > 0;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
}
