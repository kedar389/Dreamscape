using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager instance = null;
    [SerializeField]
    GameObject platformPrefab;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Start()
    {
        Instantiate(platformPrefab, transform.position, platformPrefab.transform.rotation);

    }

    IEnumerator SpawnPlatform(Vector3 spawnPosition)
    {

        yield return new WaitForSeconds(4f);
        Instantiate(platformPrefab, spawnPosition, platformPrefab.transform.rotation);
    }
}
