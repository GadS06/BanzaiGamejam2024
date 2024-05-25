using UnityEngine;

public class Cat : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float horAcceleration = 40f;
    public float airDeceleration = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public Rigidbody rb;
    public bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.Raycast(groundCheck.position, -transform.up, 0.1f, groundLayer);

        // Handle player input for movement
        AccelerateHorVel();

        // Handle player input for jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
        }
    }

    private void AccelerateHorVel()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        var desired = moveInput * moveSpeed;

        // если есть инпут
        if (Mathf.Abs(moveInput) > 0)
        {
            // если мы уже движемс€ туда с достаточной скоростью, то ничего
            if (Mathf.Sign(desired) == Mathf.Sign(rb.velocity.x)
                && Mathf.Abs(rb.velocity.x) >= Mathf.Abs(desired))
            { }
            // если нет, то придавать ускорение в ту сторону с капом
            else
            {
                if (Mathf.Abs(rb.velocity.x - desired) < Time.deltaTime * horAcceleration)
                    rb.velocity += Vector3.right * (desired - rb.velocity.x);
                else
                    rb.velocity += Vector3.right * Mathf.Sign(desired - rb.velocity.x) * horAcceleration * Time.deltaTime;
            }
        }

        // если нет инпута
        else
        {
            // если мы на земле, то жЄстко тормозить
            if (isGrounded)
            {
                rb.velocity = new Vector3(desired, rb.velocity.y, 0);
            }
            // если мы в воздухе, то м€гко тормозить
            else
            {
                rb.velocity -= Vector3.right * Mathf.Sign(rb.velocity.x) * airDeceleration * Time.deltaTime;
            }
        }
    }
}