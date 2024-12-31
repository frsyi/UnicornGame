using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public GameObject[] groundPrefabs;
    public float zSpawn = 0;
    public float groundLength = 30;
    public int numberOfGround = 3;
    private List<GameObject> activeGrounds = new List<GameObject>();
    public Transform playerTransform;

    void Start()
    {
        for (int i = 0; i < numberOfGround; i++)
        {
            if (i == 0)
            {
                SpawnGround(0); 
            }
            else
            {
                SpawnGround(Random.Range(0, groundPrefabs.Length));
            }
        }
    }

    void Update()
    {
        if (playerTransform.position.z -35 > zSpawn - (numberOfGround * groundLength))
        {
            SpawnGround(Random.Range(0, groundPrefabs.Length));
            DeleteGround(); 
        }
    }

    public void SpawnGround(int groundIndex)
    {
        GameObject newGround = Instantiate(groundPrefabs[groundIndex], transform.forward * zSpawn, transform.rotation);
        activeGrounds.Add(newGround);
        zSpawn += groundLength;
    }

    public void DeleteGround()
    {
        Destroy(activeGrounds[0]);
        activeGrounds.RemoveAt(0);
    }
}
