using UnityEngine;

public class enemyLaserGraphics : MonoBehaviour
{
    // Blends between two materials

    public bool deflected = false;
    public Material material1;
    public Material material2;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();

        // At start, use the first material
        rend.material = material1;
    }

    void Update()
    {
        // ping-pong between the materials over the duration
        if (deflected == true)
        {
            rend.material = material2;
        }
    }
}