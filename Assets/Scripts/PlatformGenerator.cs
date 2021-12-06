using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab;
    [SerializeField] GameObject firstPlatform;
    [SerializeField] GameObject lastPlatform;
    public GameObject[] platforms;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] platforms = new GameObject[2];
        lastPlatform = platforms[1]; 
        Vector3 spawnPosition = new Vector3();
        for (int i = 0; i < 1; i++)
        {
            //GameObject gameObject = lastPlatform;
            //spawnPosition = Random.insideUnitCircle * 5;
            //spawnPosition.x = Random.Range(-5f, 5f);
            //spawnPosition.y += Random.Range(2f, 4f);



            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);


        }
    }

    // Update is called once per frame
    void Update()
    {
        int platformsLength = platforms.Length;
        for (int i = 0; i < platformsLength; i++)
        {
            
        }

    }
}
