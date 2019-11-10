﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hobo_Health : MonoBehaviour
{
    [SerializeField] public double currentHealth;        // Current accessible health of Hobo      
    public bool isInvulnerable = false; // For invulnerability powerup
    private double totalHealth;         // Hobo Max Health
    private double healthPercentage;    // Percentage of health 
    private int projectileDamage;
    [SerializeField] private Text healthText; 
    // Start is called before the first frame update
    void Start()
    {
        totalHealth = 100.00;           // Set the hobo health to 100
        currentHealth = totalHealth;    // start the current health to the total health
        healthPercentage = (currentHealth / totalHealth) * 100; // set healthPercentage
    }
    // Update function that adjusts the health percentage
    void UpdatePercentage()
    {
        healthPercentage = (currentHealth / totalHealth) * 100;
        if(healthPercentage <= 0)
        {
            restart();
        }
    }
     //function to reduce the health by a standard amount
    void ReduceHealth()
    {
        if (isInvulnerable == false)
        {
            if (totalHealth <= 0 || currentHealth <= 0)
            {
                return;
            }
            currentHealth = currentHealth - 10;
            UpdatePercentage();
        }
        return;
    }

    // function to reduce the health by a specific amount of damage
    public void ReduceHealth(double damageCoefficient)
    {
        if (isInvulnerable == false)
        {
            if (totalHealth <= 0 || currentHealth <= 0)
            {
                return;
            }
            currentHealth = currentHealth - damageCoefficient;
            UpdatePercentage();
        }
        return;
    }

    // function to heal by a standard amount
    void increaseHealth()
    {
        if(currentHealth >= totalHealth)
        {
            return;
        }
        currentHealth = currentHealth + 0.1;
        UpdatePercentage();
    }

    // function to heal by a specific amount
    void increaseHealth(double healCoefficient)
    {
        if(currentHealth >= totalHealth)
        {
            return;
        }
        currentHealth = currentHealth + (healCoefficient * 0.1);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Enter Collision");
        if (collision.collider.CompareTag("Bullet"))
        {
            Debug.Log("Bullet here");
            currentHealth = currentHealth - 15.0;
            UpdatePercentage();
        }
    }

    void restart()
    {
        SceneManager.LoadScene("Samplescene");
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = currentHealth.ToString(".00");
    }

    public void setInvuln()
    {
        isInvulnerable = true;
    }

    public IEnumerator StopInvuln()
    {
        yield return new WaitForSeconds(5.0f);
        isInvulnerable = false;
    }
}
