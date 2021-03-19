using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            TriggerDeathVFX();
            if (_animator)
            {
                _animator.SetTrigger("kill");
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
    
    private void TriggerDeathVFX()
    {
        if(!deathVFX) { return; }
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObject, 1f);
    }

}