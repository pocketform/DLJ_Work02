using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketHit : MonoBehaviour
{
    public float weaponDamage;

    projectileController myPC;

    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Awake()
    {
        myPC = GetComponentInParent<projectileController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer==LayerMask.NameToLayer("shootable"))
        {
            myPC.removeForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if(collision.tag=="enemy")
        {
            enemyHealth hurtEnemy = collision.gameObject.GetComponent<enemyHealth>();
            hurtEnemy.addDamage(weaponDamage);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("shootable"))
        {
            myPC.removeForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (collision.tag == "enemy")
        {
            enemyHealth hurtEnemy = collision.gameObject.GetComponent<enemyHealth>();
            hurtEnemy.addDamage(weaponDamage);
        } 
    }
}
