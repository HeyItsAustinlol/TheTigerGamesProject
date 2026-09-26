using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float fireCooldown = 2.0f;
    [SerializeField] Movement player;
    Vector2 currentDir;
    bool onCooldown = false;

    private void Update()
    {
        // Get direction
        currentDir = player.transform.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, currentDir);

        // Attempt an attack
        Attack();
    }

    /// <summary>
    /// Attempts to shoot a projectile unless it's on a cooldown
    /// </summary>
    private void Attack()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        // Check to make sure multiple timers won't run at the same time
        if (!onCooldown)
        {
            // Shoot projectile in the direction the enemy is facing
            Projectile proj = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Projectile>();
            proj.Init(currentDir);

            // Begin cooldown
            onCooldown = true;
            yield return new WaitForSeconds(fireCooldown);
            onCooldown = false;
        }
    }
}
