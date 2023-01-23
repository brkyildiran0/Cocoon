using UnityEngine;
using UnityEngine.SearchService;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float attackSpeed;
    public int attackDamage;
    public float attackCooldownDuration;
    public int currentHP;
    public int maxHP;

    private Vector3 movement;
    private float attackTimer;
    private HeadWeapon headWeapon;
    
    private SpriteRenderer bodyRenderer;


    void Start()
    {
        headWeapon = GameObject.FindGameObjectWithTag("PlayerHead").GetComponent<HeadWeapon>();

        bodyRenderer = GameObject.FindGameObjectWithTag("PlayerBody").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal > 0)
        {
            bodyRenderer.flipX = false;
        }
        else if (horizontal < 0)
        {
            bodyRenderer.flipX = true;
        }

        movement = new Vector3(horizontal, vertical, 0f);
        transform.position += movement * movementSpeed * Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            if (attackTimer <= 0)
            {
                Attack();
                attackTimer = attackCooldownDuration;
            }
        }
        attackTimer -= Time.deltaTime;
    }

    void Attack()
    {
        headWeapon.Attack();
    }
}