using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemySpawn;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minZ;
    [SerializeField] float maxZ;
    // Start is called before the first frame update
    void Start()
    {

       
        
    }

    private void Awake()
    {
        Instantiate(enemySpawn, GenerateSpawnPosition(), enemySpawn.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 
    private Vector3 GenerateSpawnPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);
        Vector3 randomPos = new Vector3(randomX, 0, randomZ);
        return randomPos;
    }
}

