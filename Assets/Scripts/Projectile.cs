using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Sprite[] FoodSprites;
    [SerializeField] float Speed = 3f;
    [SerializeField] float LifeSpan = 5f;
    [SerializeField] AnimationCurve MoveCurve;
    Vector3 projDir, startPos, step;
    SpriteRenderer rend;
    float curval = 0;

    /// <summary>
    /// Initialize the projectile with a direction and random sprite.
    /// </summary>
    /// <param name="shootDirection"></param>
    public void Init(Vector3 shootDirection)
    {
        projDir = shootDirection;
        
        // Set a random sprite
        rend = GetComponent<SpriteRenderer>();
        int randChoice = Random.Range(0, FoodSprites.Length);
        rend.sprite = FoodSprites[randChoice];

        startPos = transform.position;
        step = startPos + (projDir * LifeSpan);
    }

    private void FixedUpdate()
    {
        curval = Mathf.MoveTowards(curval, 1, Speed * Time.fixedDeltaTime);
        transform.position = Vector3.Lerp(startPos, step, MoveCurve.Evaluate(curval));

        if (curval == 1) KillProjectile();
    }

    /// <summary>
    /// Destroys the projectile
    /// </summary>
    public void KillProjectile()
    {
        Destroy(gameObject);
    }
}
