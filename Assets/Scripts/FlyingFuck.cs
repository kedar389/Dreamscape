using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingFuck : MonoBehaviour
{
    public DetectionZone attackZone; // Add missing semicolon
    float deltaTime;
	GameObject targetObject;

	Animator animator; // Add missing semicolon

    private bool _hasTarget = false;
    public bool HasTarget
    {
        get { return _hasTarget; }
        private set
        {
            _hasTarget = value; // Correct variable name from "valuel" to "value"
            animator.SetBool("hasTarget", value);
			deltaTime = Time.time;

		}
    } 

    void Update()
    {
        HasTarget = attackZone.detectedColliders.Count > 0;
        if (HasTarget && deltaTime-Time.time>0.5) { 
            deltaTime = Time.time;
			PlayerController targetScript = targetObject.GetComponent<PlayerController>();
            targetScript.Health -= 15;
		}
    }

    private void Awake()
    {
		targetObject = GameObject.Find("Nightmare player");
		animator = GetComponent<Animator>();
    }
}
