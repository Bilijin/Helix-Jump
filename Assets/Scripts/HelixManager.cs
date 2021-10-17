using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour
{
    public GameObject[] helixRings;
    public float ySpawn = 0;
    public float ringDistance = 5;
    public int noOfRings;
    public GameObject lastRing;

    // Start is called before the first frame update
    void Start()
    {
        noOfRings = GameManager.currentLevelIdx + 3;
        for (int i = 0; i < noOfRings; i++)
        {
            if (i == 0)
            {
                SpawnRing(0);
            }
            else
            {
                SpawnRing(Random.Range(01, helixRings.Length - 1));
            }
        }

        SpawnRing(helixRings.Length - 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRing(int ringIdx)
    {
        GameObject ring = Instantiate(helixRings[ringIdx], transform.up * ySpawn, Quaternion.identity);
        ring.transform.parent = transform;

        ySpawn -= ringDistance;
    }
}
