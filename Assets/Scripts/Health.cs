using UnityEngine;
using static UnityEngine.Mathf;

public class Health : MonoBehaviour
{

    public delegate void HealthUpdate(int oldAmount, int newAmount, int max);
    public event HealthUpdate OnHpUpdate;

    private const int MAX_HEALTH = 100;

    [SerializeField]
    private int health = MAX_HEALTH;

    private Animator animator;
    public GameObject cross;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SpawnCross()
    {
        Vector2 spawnPosition = new Vector2
        {
            x = transform.position.x,
            y = -0.1f
        };
        Instantiate(cross, spawnPosition, Quaternion.identity);
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage()
    {
        int current = health;
        int damage = 10;
        health = Max(health - damage, 0);
        animator.SetInteger("Health", health);
        animator.SetTrigger("TookDamage");

        if (OnHpUpdate != null)
        {
            OnHpUpdate(current, health, MAX_HEALTH);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent != transform
            && collision.gameObject.CompareTag("Hitbox"))
        {

            TakeDamage();
        }
    }
}
