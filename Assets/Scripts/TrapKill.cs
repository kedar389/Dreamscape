using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TrapKill : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject PlayerPrefab;
	public TilemapCollider2D coll;
	public LayerMask groundLayer;
	// Start is called before the first frame update
	void Start()
    {
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
