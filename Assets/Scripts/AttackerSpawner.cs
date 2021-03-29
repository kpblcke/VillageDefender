using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] 
    private float firstSpawnDelay = 10f;
    
    [SerializeField]
    private float minSpawnDelay = 1f;
    [SerializeField]
    private float maxSpawnDelay = 5f;

    [SerializeField]
    private Attacker[] attackers;
    private bool spawn = true;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(firstSpawnDelay + Random.Range(minSpawnDelay, maxSpawnDelay));
        while (spawn)
        {
            SpawnAttacker();
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
        }
    }

    public void StopSpawn()
    {
        spawn = false;
    }

    void SpawnAttacker()
    {
        Attacker attackerPrefab = attackers[Random.Range(0, attackers.Length)];
        Attacker newAttacker = Instantiate(attackerPrefab, transform.position, transform.rotation, transform);
    }
}
