using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 10f;
    [SerializeField] float MoveSmoothing = 0.05f;
    private Rigidbody2D rb;
    private Vector3 vel = Vector3.zero;
    public bool facingleft, horizontal, up;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Grab Input on Axes
        float horz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");

        // Multiply by Time.fixedDelta to keep consistent movement
        float horzMove = horz * Time.fixedDeltaTime;
        float vertMove = vert * Time.fixedDeltaTime;

        // Move the player
        Move(horzMove, vertMove);
    }

    /// <summary>
    /// Move the player based on X and Y axes
    /// </summary>
    /// <param name="moveX"></param>
    /// <param name="moveY"></param>
    private void Move(float moveX, float moveY)
    {
        // Move the player smoothly
        Vector3 targetvel = new Vector3(moveX, moveY).normalized * MoveSpeed;
        rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, targetvel, ref vel, MoveSmoothing);

        // Animate
        if (!GetComponent<Player>().Swiping)
        {
            if (Mathf.Abs(moveY) > Mathf.Abs(moveX) && moveY > 0)
            {
                GetComponent<Animator>().Play("WalkUp");
                horizontal = false;
                up = true;
            }
            if (Mathf.Abs(moveY) > Mathf.Abs(moveX) && moveY < 0)
            {
                GetComponent<Animator>().Play("WalkDown");
                horizontal = false;
                up = false;
            }
            if (Mathf.Abs(moveX) > Mathf.Abs(moveY))
            {
                GetComponent<Animator>().Play("WalkHorz");
                horizontal = true;
                up = false;
            }
        }

        // If horizontal facing, flip the sprite if the bool does not match
        if (horizontal)
        {
            if (moveX < 0 && !facingleft) Flip();
            else if (moveX > 0 && facingleft) Flip();
        }
    }

    /// <summary>
    /// Flips the player transform
    /// </summary>
    private void Flip()
    {
        // Flip boolean
        facingleft = !facingleft;

        // Flip sprite
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}