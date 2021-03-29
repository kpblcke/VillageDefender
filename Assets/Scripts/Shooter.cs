using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField] GameObject projectile, gun;
    [SerializeField] private float shootCooldown = 0.5f;
    private bool canShoot = true;
    
    private Animator _animator;
    AttackerSpawner myLaneSpawner;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    private void Start()
    {
        _animator = GetComponent<Animator>();
        SetLaneSpawner();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if(!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Update()
    {
        if(IsAttackerInLane() && canShoot)
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

    IEnumerator ReduceCooldown()
    {
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }

    private bool IsAttackerInLane()
    {
        if (!myLaneSpawner)
        {
            return false;
        }
        return myLaneSpawner.transform.childCount > 0;
    }
    
    public void Fire()
    {
        canShoot = false;
        Instantiate(projectile, gun.transform.position, transform.rotation, projectileParent.transform);
        StartCoroutine(ReduceCooldown());
    }
}