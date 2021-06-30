using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{   
    public Transform[] spawnPoints;
    public GameObject[] meteoro;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawning());
    }
    IEnumerator StartSpawning(){
        yield return new WaitForSeconds(Random.Range(0f,2.5f));
        Instantiate(meteoro[Random.Range(0,meteoro.Length)],spawnPoints[Random.Range(0,spawnPoints.Length)].position,
        Quaternion.identity);
        StartCoroutine(StartSpawning());
    }
}
