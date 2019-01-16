using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Health : NetworkBehaviour
{
    public float timer = 10.0f;

    public const float maxHealth = 1;
    [SyncVar] public float currentHealth = maxHealth;

    void Update()
    {
        timer -= 5.0f * Time.deltaTime;
        if (timer < 0 & currentHealth < 0)
        {
            gameObject.SetActive(true);
            Debug.Log("Alive");
            currentHealth = 100;
        }
    }


    public void TakeDamage(float amount)
    {
        if(!isServer)
        {
            return;
        }

        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = maxHealth;
            gameObject.SetActive(false);
            Debug.Log("Dead");
        }
    }
}