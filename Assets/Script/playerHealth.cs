using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float fullHealth;
    public GameObject deathFX;
    public Image damagescreen;

    float currentHealth;

    bool damaged = false;
    Color damagedColor = new Color(0f, 0f, 0f, 0.5f);
    float smoothColor = 5f;

    playerController controlMovement;

    //HD Object
    public GameObject blood1;
    public GameObject blood2;
    public GameObject blood3;
    public GameObject blood4;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = fullHealth;

        controlMovement = GetComponent<playerController>();

        //HD Initialization
        

    }

    // Update is called once per frame
    void Update()
    {
        if (damaged)
        {
            damagescreen.color = damagedColor;
        }
        else
        {
            damagescreen.color = Color.Lerp(damagescreen.color, Color.clear, smoothColor * Time.deltaTime);
        }
        damaged = false;
    }
    public void addDamage(float damage)
    {
        if (damage <= 0) return;
        
        currentHealth -= damage;
        if (currentHealth== fullHealth-damage) blood4.SetActive(false);
        if (currentHealth == fullHealth - 2*damage) blood3.SetActive(false);
        if (currentHealth == fullHealth - 3*damage) blood2.SetActive(false);
        if (currentHealth == fullHealth - 4*damage) blood1.SetActive(false);
        damaged = true;

        if (currentHealth<=0)
        {
            makeDead();
        }
    }
    public void addHealth(float healthAmount)
    {
        currentHealth += healthAmount;
        if (currentHealth == 2 * healthAmount) blood2.SetActive(true);
        if (currentHealth == 3 * healthAmount) blood3.SetActive(true);
        if (currentHealth == 4 * healthAmount) blood4.SetActive(false);
    }

    public void makeDead()
    {
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject); 
    }



}