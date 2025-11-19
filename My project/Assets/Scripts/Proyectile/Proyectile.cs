using UnityEngine;

public class Proyectile : MonoBehaviour
{
    [SerializeField]
    float speed = 20f;
    Vector2 direction;
    [SerializeField]
    public GameObject player;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = (player.transform.position - transform.position).normalized;
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //rb.AddForce(direction * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("A");
        if (collision.gameObject.CompareTag("Object"))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("B");
        if (collision.gameObject.CompareTag("Object"))
        {
            Destroy(gameObject);
        }
    }
}
