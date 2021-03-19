using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField] float speed = 1f;
    [SerializeField] float damage = 50;

    [SerializeField] private GameObject deathVfx; 

    void Update ()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();
        
        if (attacker && health)
        {
            health.DealDamage(damage);
            if (deathVfx)
            {
                Instantiate(deathVfx, transform.position, transform.rotation, transform.parent);
            }
            Destroy(gameObject);
        }
    }
}