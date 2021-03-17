using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField] GameObject projectile, gun;
    private Animator _animator;
    
    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, transform.rotation);
    }
    
    AttackerSpawner myLaneSpawner;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        SetLaneSpawner();
    }

    private void Update()
    {
        if(IsAttackerInLane())
        {
            _animator.SetBool("isAttacking", true);
        }
        else
        {
            _animator.SetBool("isAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            bool IsCloseEnough = 
                (Mathf.Abs(spawner.transform.position.y - transform.position.y) 
                 <= Mathf.Epsilon);
            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        return myLaneSpawner.transform.childCount > 0;
    }

}