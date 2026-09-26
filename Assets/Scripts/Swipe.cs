using UnityEngine;

public class Swipe : MonoBehaviour
{
    [SerializeField] float Radius = 1f;

    /// <summary>
    /// Destroys all projectiles in range
    /// </summary>
    public void SwipeObjects()
    {
        // Get every Projectile object in range.
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, Radius);

        foreach (Collider2D col in cols)
        {
            if (col.transform.GetComponent<Projectile>() != null)
            {
                col.GetComponent<Projectile>().KillProjectile();
                FindFirstObjectByType<Player>().updateEnemiesKilled();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
