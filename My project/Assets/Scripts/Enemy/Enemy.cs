using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    GameObject player;
    Vector3 moveDir;
    [SerializeField]
    GameObject projectile;
    [SerializeField]
    float moveSpeed = 15f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        moveDir = Vector2.zero;
        InvokeRepeating(nameof(ThrowProjectile), 2f, 2f);
    }

    void Update()
    {
        moveDir = (player.transform.position - transform.position).normalized;
    }

    private void FixedUpdate()
    {
        //rb.MovePosition((player.transform.position - transform.position).normalized);
        //Vector3 dir = (player.transform.position - transform.position).normalized;
        //rb.MovePosition(transform.position + moveDir * 4f * Time.fixedDeltaTime);
        rb.AddForce(moveDir * moveSpeed);
    }

    private void ThrowProjectile()
    {
        Proyectile p = Instantiate(projectile, transform.position, transform.rotation, transform.parent).GetComponent<Proyectile>();
        p.player = player;
    }
}
