using System.Collections;
using System.Collections.Generic;
using Anatinus.My_Scripts.Gameplay;
using UnityEngine;

public class enemyLaser : MonoBehaviour
{
    public bool deflected = false;
    public float originalSpeed = 20;
    public float speed;
    public float dmg;
    private enemyLaserGraphics _graphics;

    // Start is called before the first frame update
    void Start()
    {
        _graphics = GetComponentInChildren<enemyLaserGraphics>();
        speed = originalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);

        if (deflected == true)
        {
            gameObject.layer = 10;
            _graphics.deflected = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject hit = collision.gameObject;
        Health health = hit.GetComponent<Health>();

        if (health != null)
        {
            health.TakeDamage(dmg);
            /*LeanPool.*/
            Destroy(gameObject);
        }
    }
}
