using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapKill : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject PlayerPrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player") || coll.gameObject.CompareTag("Nightmare"))
        {
            //Debug.Log("I am in");
            StartCoroutine(Respawn());
        }

    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1f);
        GameObject.FindGameObjectWithTag("Nightmare").transform.position = spawnPoint.position;

    }
    // Update is called once per frame
    void Update()
    {


    }
}
