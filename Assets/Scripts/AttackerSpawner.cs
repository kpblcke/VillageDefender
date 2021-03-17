using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField]
    private float minSpawnDelay = 1f;
    [SerializeField]
    private float maxSpawnDelay = 5f;

    [SerializeField]
    private Attacker attackerPrefab;
    
    private bool spawn = true;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawning());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
        while (spawn)
        {
            SpawnAttacker();
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
        }
    }

    void SpawnAttacker()
    {
        Attacker newAttacker = Instantiate(attackerPrefab, transform.position, transform.rotation, transform);
    }
}
