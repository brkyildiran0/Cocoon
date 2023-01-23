using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;
    public float lifetime;
    private float timer;

    void Start()
    {
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyController>().currentHP -= damage;
            Destroy(gameObject);
        }
    }
}