using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)]
    [SerializeField] 
    float walkSpeed = 0f;
    GameObject currentTarget;

    private void Start()
    {
        FindObjectOfType<LevelController>().SpawnAttacker();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);
        UpdateAnimationState();
    }
    
    private void UpdateAnimationState()
    {
        if(!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed(float newSpeed)
    {
        walkSpeed = newSpeed;
    }
    
    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }
    
    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) { return; }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
    }

    private void OnDestroy()
    {
        LevelController haveController = FindObjectOfType<LevelController>();
        if (haveController)
        {
            haveController.AttackerDead();
        }
    }
}
