using Unity.VisualScripting;
using UnityEngine;

public class Fish : MonoBehaviour
{

    public ConstantForce2D constantForce2D;
    private GameObject target;
    private Rigidbody2D rb2D;


    private void Awake()
    {
        constantForce2D.enabled = false;
        rb2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rb2D.AddForce(new Vector2(-5, 0));
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.GetInstance().TakeDamage(1);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DecisionPoint"))
        {
            if (Player.GetInstance().transform.position.y < -1)
            {
                SwimToPlayer();
            }
            else
            {
                JumpToPlayer();
            }
        }
    }

    void SwimToPlayer()
    {
        constantForce2D.enabled = true;
    }
    void JumpToPlayer()
    {
        target = GameObject.Find("Player");
        Vector2 projectileVelocity = CalculateProjectileVelocity(transform.position, target.transform.position, 1f);
        rb2D.linearVelocity = projectileVelocity;
    }

    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float time)
    {
        Vector2 distance = target - origin;

        float velocityX = distance.x / time;
        float velocityY = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

        return new Vector2(velocityX, velocityY);
    }
}
