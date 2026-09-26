using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float fireRate = 0.5f;
    public GameObject projectile;
    public float fireCooldown = 2.0f;
    public Movement player;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
    }
}
