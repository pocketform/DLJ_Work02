using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public float enemyHealthMax;

    public GameObject enemyDeathFX;

    public bool drops;
    public GameObject theDrop;

    float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = enemyHealthMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     
    public void addDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) makeDead();
    }

    void makeDead()
    {
        Destroy(gameObject);
        Instantiate(enemyDeathFX, transform.position, transform.rotation);
        if (drops) Instantiate(theDrop, transform.position, transform.rotation);
    }
}
