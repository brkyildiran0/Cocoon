using UnityEngine;

public class HeadWeapon : MonoBehaviour
{
    public float attackSpeed;
    public int attackDamage;

    [SerializeField] PooledObject projectileReferenceToBeSpawned;
    [SerializeField] Transform projectileSpawnPosition;

    private PlayerController player;
    private Vector2 mousePos;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Rotate the weapon to face the cursor
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePos.x - transform.position.x > 0f)
        {
            spriteRenderer.flipY = false;
            projectileSpawnPosition.localPosition = new Vector2(0.35f, 0.4f);
        }
        else
        {
            spriteRenderer.flipY = true;
            projectileSpawnPosition.localPosition = new Vector2(0.35f, -0.4f);
        }
        transform.right = mousePos - (Vector2)transform.position;
    }

    public void Attack()
    {
        // Get the attack speed and damage from the player
        attackSpeed = player.attackSpeed;
        attackDamage = player.attackDamage;

        // Instantiate the projectile
        PooledObject projectile = Pool.Instance.Spawn(projectileReferenceToBeSpawned, projectileSpawnPosition.position, transform.rotation);

        // Add velocity to the projectile in the direction of the cursor
        projectile.GetComponent<Rigidbody2D>().velocity = (mousePos - (Vector2)projectileSpawnPosition.position).normalized * attackSpeed;

        // Set the projectile's damage
        projectile.GetComponent<Projectile>().damage = attackDamage;
    }
}