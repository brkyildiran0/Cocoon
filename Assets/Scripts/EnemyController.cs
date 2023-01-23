using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float movementSpeed;
    public float attackSpeed;
    public float attackDamage;
    public int currentHP;

    private Transform player;
    private float attackTimer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        attackTimer = 0f;
    }

    void Update()
    {
        Vector3 target = player.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
        transform.position = Vector3.MoveTowards(transform.position, target, movementSpeed * Time.deltaTime);

        attackTimer += Time.deltaTime;
        if (attackTimer >= attackSpeed)
        {
            Attack();
            attackTimer = 0f;
        }
    }

    void Attack()
    {
        // Perform attack logic here
    }
}
