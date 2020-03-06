using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject obstacle;
    [Range(0,10)]
    public float minSpawnDelay;
    [Range(0,10)]
    public float maxSpawnDelay;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Spawn()
    {
        GameObject go = Instantiate(obstacle, this.transform.position, Quaternion.identity) as GameObject;
        yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
        StartCoroutine(Spawn());
    }
}
