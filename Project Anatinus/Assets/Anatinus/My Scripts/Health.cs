using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Health : NetworkBehaviour
{
    [SyncVar] public float maxHealth;
    [SyncVar] public float currentHealth;


    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = maxHealth;
            gameObject.SetActive(false);
            Debug.Log("Dead");
        }
    }
}