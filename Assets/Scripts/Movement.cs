using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 10f;
    [SerializeField] float MoveSmoothing = 0.05f;
    private Rigidbody rb;
    private Vector3 vel = Vector3.zero;
    bool facingleft, horizontal;

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

    private void Move(float moveX, float moveY)
    {
        // Move the player smoothly
        Vector3 targetvel = new Vector3(moveX, moveY).normalized * MoveSpeed;
        rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, targetvel, ref vel, MoveSmoothing);

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