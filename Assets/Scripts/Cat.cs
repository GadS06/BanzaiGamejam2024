using UnityEngine;
using UnityEngine.UI;

public class Cat : MonoBehaviour
{
    public int maxHp = 6;
    public int hp;
    public float moveSpeed = 5f;
    public float waterMoveSpeed = 5f;
    public float jumpForce = 10f;
    public float horAcceleration = 40f;
    public float airDeceleration = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public Rigidbody rb;
    public Buoyancy buoyancy;
    public bool isGrounded;

    private Slider catHp;

    private void Start()
    {
        hp = maxHp;
        rb = GetComponent<Rigidbody>();
        buoyancy = GetComponent<Buoyancy>();
        catHp = FindObjectOfType<CatHpUI>(true).GetComponent<Slider>();
    }

    private void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.Raycast(groundCheck.position + transform.up * 0.1f, -transform.up, 0.2f, groundLayer);

        // Handle player input for movement
        AccelerateHorVel();

        // Handle player input for jumping
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || buoyancy.floating))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
        }

        UpdateUI();
    }

    private void AccelerateHorVel()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        var desired = moveInput * (buoyancy.floating ? waterMoveSpeed : moveSpeed);

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

    void UpdateUI()
    {
        if (hp == maxHp)
        {
            catHp.gameObject.SetActive(false);
        }
        else
        {
            catHp.gameObject.SetActive(true);
            catHp.maxValue = maxHp;
            catHp.minValue = 0;
            catHp.value = hp;
        }
    }

    public void AddHp(int _hp)
    {
        hp += _hp;
        if (hp > maxHp)
            hp = maxHp;
        if (hp <= 0)
            FindObjectOfType<GameManager>().GameOver();
    }
}