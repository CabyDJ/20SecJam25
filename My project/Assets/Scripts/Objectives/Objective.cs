using System.ComponentModel;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class Objective : MonoBehaviour
{
    [SerializeField]
    public int score = 100; 
    [SerializeField]
    public int scoreOnBreak = 0;
    private int scoreThisHit = 0;
    [SerializeField]
    private int hp = 1;
    private int maxHp;
    [SerializeField]
    private bool canDestroy = false;
    private bool _isDestroyed = false;
    public bool isDestroyed { 
        get 
        { 
            return _isDestroyed; 
        }
        set
        {
            _isDestroyed = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(isDestroyed)));
        } 
    }
    [SerializeField]
    private GameObject PointsGO;
    [SerializeField]
    private GameObject HitGO;
    [SerializeField]
    private ParticleSystem particlesSys;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite[] damageSprites;
    [SerializeField]
    private GameObject colliderGO;
    private Collider2D coll2d;

    [SerializeField]
    private ShakeController shakeCont;
    [HideInInspector]
    public event PropertyChangedEventHandler PropertyChanged;

    [SerializeField]
    AudioClip[] destroyAudioClipsHit;
    [SerializeField]
    AudioClip[] hitAudioClipsHit;

    private void Awake()
    {
        if(shakeCont == null)
            shakeCont = GetComponentInChildren<ShakeController>();
        coll2d = colliderGO.GetComponent<Collider2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxHp = hp;
    }

    private void ShowHitEffects(Vector3 pos)
    {
        //GameObject go = Instantiate(HitGO);
        //go.transform.position = pos;
        if (!isDestroyed)
        {
            GameObject pointsGO = Instantiate(PointsGO);
            pointsGO.transform.position = pos;
            ShowPoints sp = pointsGO.GetComponent<ShowPoints>();
            sp.SetPoints(/*score*/ scoreThisHit);
        }

        shakeCont.SetShake();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile")) 
        {
            //Debug.Log("+ SCORE");
            //GameManager.instance.ChangeScore(score);
            TakeDamage(collision.gameObject.transform.position);
        }
    }

    private void TakeDamage(Vector3 pos)
    {
        hp--;

        UpdateScore();
        ShowHitEffects(pos);
        CheckDestroyed();
        ChangeSprite();
    }

    private void UpdateScore()
    {
        if (!isDestroyed && scoreOnBreak == 0)
            scoreThisHit = score;
        else if (!isDestroyed && hp <= 0 && scoreOnBreak != 0)
            scoreThisHit = scoreOnBreak;
        else
            scoreThisHit = 0;

        GameManager.instance.ChangeScore(scoreThisHit);
    }

    private void CheckDestroyed()
    {
        if(hp <= 0 && !isDestroyed)
        {
            isDestroyed = true;
            StartDestroy();
            PlayDestroyedSound();
        }
        else
        {
            PlayHitSound();
        }
    }

    private void PlayHitSound()
    {
        SoundManager.instance.PlaySound(hitAudioClipsHit, transform, 1f);
    }

    private void PlayDestroyedSound()
    {
        SoundManager.instance.PlaySound(destroyAudioClipsHit, transform, 1f);
    }

    private void StartDestroy()
    {
        particlesSys.Play();
        if (canDestroy)
        {
            //particlesSys.transform.parent = null;
            //Destroy(gameObject);
            //coll2d.enabled = false;
            coll2d.isTrigger = true;
        }
    }

    private void ChangeSprite()
    {
        if (damageSprites.Length > 0)
        {
            if (hp <= 0)
            {
                spriteRenderer.sprite = damageSprites[0];
            }
        }
    }
}
