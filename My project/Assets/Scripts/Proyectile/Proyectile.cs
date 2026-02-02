using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Proyectile : MonoBehaviour
{
    [SerializeField]
    float speed = 20f;
    Vector2 direction;
    [SerializeField]
    public GameObject player;
    Rigidbody2D rb;
    [SerializeField]
    private GameObject PointsGO;
    [SerializeField]
    private GameObject HitGO;
    [SerializeField]
    private SpriteRenderer spriteRender;
    [SerializeField]
    private Collider2D col;
    [SerializeField]
    private TrailRenderer trail;
    //[SerializeField]
    //private Sprite[] sprites;

    [SerializeField]
    AudioClip[] audioClipsHit;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //trail.emitting = false;
        spriteRender.enabled = false;
        col.enabled = false;
        //rb.Sleep();
        //direction = (player.transform.position - transform.position).normalized;
        //rb.AddForce(direction * speed, ForceMode2D.Impulse);

        //spriteRender.sprite = sprites[Random.Range(0, sprites.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //rb.AddForce(direction * speed);
    }

    public Sprite GetSprite()
    {
        return spriteRender.sprite;
    }

    public void StartThrow()
    {
        //rb.simulated = true;
        trail.Clear();
        spriteRender.enabled = true;
        col.enabled = true;

        direction = (player.transform.position - transform.position).normalized;
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }

    private void SpawnEffect(Vector2 pos)
    {
        GameObject go = Instantiate(HitGO);
        go.transform.position = pos;

        if (audioClipsHit != null)
            SoundManager.instance.PlaySound(audioClipsHit, transform, 1f);

        //GameObject go2 = Instantiate(PointsGO);
        //go2.transform.position = pos;
        //ShowPoints sp = go2.GetComponent<ShowPoints>();
        //sp.SetPoints(score);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("A");
        if (collision.gameObject.CompareTag("Object"))
        {
            SpawnEffect(transform.position);
            Destroy(gameObject);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    //Debug.Log("B");
    //    if (collision.gameObject.CompareTag("Object"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
