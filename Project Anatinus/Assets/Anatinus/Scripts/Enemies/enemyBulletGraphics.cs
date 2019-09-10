using UnityEngine;

public class enemyBulletGraphics : MonoBehaviour
{
    // Blends between two materials

    public bool deflected = false;
    public Material material1;
    public Material material2;
    public Material material3;
    public float duration = 1.0f;
    Renderer _rend;

    void Start()
    {
        _rend = GetComponent<Renderer>();

        // At start, use the first material
        _rend.material = material1;
    }

    void Update()
    {
        // ping-pong between the materials over the duration
        if (deflected == false)
        {
            float lerp = Mathf.PingPong(Time.time, duration) / duration;
            _rend.material.Lerp(material1, material2, lerp);
        }
        else
        {
            _rend.material = material3;
        }
    }
}