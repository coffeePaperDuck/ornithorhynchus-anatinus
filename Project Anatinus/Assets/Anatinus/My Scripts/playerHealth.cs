using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class playerHealth : NetworkBehaviour
{

    public const int maxHealth = 1;
    [SyncVar] public int currentHealth = maxHealth;

    public void TakeDamage(int amount)
    {
        if(!isServer)

        {
            return;
        }


        {
            currentHealth -= amount;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Debug.Log("Dead");
            }


            


        }

    }

}


    


