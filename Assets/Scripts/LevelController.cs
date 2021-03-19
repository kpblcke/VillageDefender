using System;
using System.Collections;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] float waitToLoad = 4f;
    [SerializeField] private GameObject winLabel;
    [SerializeField] private GameObject loseLabel;
    
    private int attackersCount = 0;
    private bool levelTimerFinished;
    
    private AttackerSpawner[] _spawners;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
        _spawners = FindObjectsOfType<AttackerSpawner>();
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        foreach (var spawner in _spawners)
        {
            spawner.StopSpawn();
        }
    }

    public void SpawnAttacker()
    {
        attackersCount++;
    }

    public void AttackerDead()
    {
        attackersCount--;
        if (attackersCount <= 0 && levelTimerFinished && !loseLabel.activeInHierarchy)
        {
            StartCoroutine(HandleWinCondition());
        }
    }
    
    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }
    
    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }
}