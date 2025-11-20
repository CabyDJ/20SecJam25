using System.Collections;
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
    [SerializeField]
    float throwTime = 2f; //throw projectile every X seconds
    float moveSpeedBonus = 1f;
    float throwTimeBonus = 1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        moveDir = Vector2.zero;
        InvokeRepeating(nameof(ThrowProjectile), 2f, throwTime);
        StartCoroutine(HalfTimeBonus());
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
        rb.AddForce(moveDir * (moveSpeed * moveSpeedBonus));
    }

    private void ThrowProjectile()
    {
        Proyectile p = Instantiate(projectile, transform.position, transform.rotation, transform.parent).GetComponent<Proyectile>();
        p.player = player;
    }

    private IEnumerator HalfTimeBonus()
    {
        yield return new WaitForSeconds(10);
        moveSpeedBonus += 0.5f;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log("PLAYER ENTER");
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log("PLAYER EXIT");
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("PLAYER ENTER");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("PLAYER EXIT");
        }
    }
}
