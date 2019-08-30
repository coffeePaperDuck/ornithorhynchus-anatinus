using UnityEngine;

namespace Anatinus.My_Scripts.Gameplay
{
    public class Health : MonoBehaviour
    {
        public float maxHealth;
        public float currentHealth;


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
}