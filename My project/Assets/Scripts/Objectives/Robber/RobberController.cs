using System.Collections;
using UnityEngine;

public class RobberController : MonoBehaviour
{
    [SerializeField]
    private float SpawnTime = 10f;
    [SerializeField]
    private float EnterTime = 3f;

    [SerializeField]
    private GameObject spriteGO;
    [SerializeField]
    private SpriteRenderer sprite;
    [SerializeField]
    private Animator spriteAnim;
    [SerializeField]
    private GameObject hitboxGO;
    [SerializeField]
    private Objective piggy;
    [SerializeField]
    private GameObject piggyGO;
    [SerializeField]
    private SpriteRenderer piggySprite;
    [SerializeField]
    private GameObject piggyHB;
    [SerializeField]
    private WindowController windowsCont;

    [SerializeField]
    private Animator anim;
    private bool isWalking;
    private bool isExiting;
    private bool atPiggy;
    private Vector3 target = new Vector3(6.125f, 7.6875f, 0);
    private Vector3 exitTarget = new Vector3(/*8f*/10.0625f,/*7.25f*/ 6.25f, 0);
    private Vector3 piggyPos;
    private bool isRobbing;
    private bool isHit;
    private bool isGrabbingPiggy;

    private void Start()
    {
        StartCoroutine(SpawnCount());
    }

    private void Update()
    {
        if (isRobbing)
        {
            if (isExiting)
            {
                float speed = 5.5f * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, exitTarget, speed);

                if (transform.position == exitTarget)
                {
                    atPiggy = true;
                    isExiting = false;
                    StartCoroutine(JumpWindow());
                }
            }
            else if (isWalking && !isHit)
            {
                float speed = 2f * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target, speed);

                if (transform.position == target)
                {
                    atPiggy = true;
                    isWalking = false;
                    StartCoroutine(StealPiggy());
                }

            }

            if (piggy.isDestroyed && !isHit)
            {
                StartCoroutine(GetHit());
            }
        }
    }

    private IEnumerator SpawnCount()
    {

        yield return new WaitForSeconds(SpawnTime);

        spriteGO.SetActive(true);
        spriteAnim.Play("RobberUp");

        yield return new WaitForSeconds(EnterTime);

        if (!piggy.isDestroyed && GameManager.score < 2500)
        {
            StartCoroutine(EnterHouse());
        }
        else
        {
            spriteAnim.Play("RobberDown");
            StopRobbing();
        }
    }

    private IEnumerator EnterHouse()
    {
        windowsCont.OpenWindow();
        yield return new WaitForSeconds(1f);
        sprite.sortingOrder = 2;
        spriteAnim.Play("RobberEnter");
        transform.position = new Vector3(10, 6.625f, 0);

        yield return new WaitForSeconds(1.5f);
        if (!isHit)
        {
            spriteAnim.Play("RobberWalk");
            isWalking = true;
            windowsCont.CloseWindow();
        }
        //anim.Play("RobberDownMotionWalk");
        //yield return new WaitForSeconds(1.9f);
        //spriteAnim.Play("RobberIdle");
    }

    public void ActiveHB()
    {
        hitboxGO.SetActive(true);
        isRobbing = true;
    }

    private IEnumerator StealPiggy()
    {
        //Time.timeScale = 0.25f;
        spriteAnim.Play("RobberIdle");
        yield return new WaitForSeconds(0.5f);
        if (!isHit)
        {
            spriteAnim.Play("RobberSteal");
        }
    }

    public void GrabPiggy()
    {
        isGrabbingPiggy = true;
        piggyPos = piggyGO.transform.position;
        piggyGO.transform.position = new Vector3(4.0625f, 7.375f, 0);
        piggySprite.sortingOrder = 4;
        piggyHB.SetActive(false);
        //DISABLE PIGGY HITBOX?
    }

    public void PiggyBag()
    {
        piggyGO.SetActive(false);
    }
    public void ReturnPiggy()
    {
        if (isGrabbingPiggy)
        {
            piggyGO.transform.position = piggyPos;
            piggySprite.sortingOrder = 1;
            piggyHB.SetActive(true);
        }
    }
    private void StopRobbing()
    {
        isRobbing = false;
        hitboxGO.SetActive(false);
    }

    public void HideRobber()
    {
        //hitboxGO.SetActive(false);
        //sprite.enabled = false;
        spriteGO.SetActive(false);
    }

    public void StartExiting()
    {
        isExiting = true;
        spriteAnim.Play("RobberWalk");
        //StartCoroutine(JumpWindow());
        windowsCont.OpenWindow();
    }

    private IEnumerator JumpWindow()
    {
        StopRobbing();
        spriteAnim.Play("RobberExit");
        //yield return new WaitForSeconds(0.5f);
        //OpenWindow();
        yield return new WaitForSeconds(0.5f);
        windowsCont.CloseWindow();
    }

    private IEnumerator GetHit()
    {
        isHit = true;
        isWalking = false;
        isExiting = false;
        spriteAnim.Play("RobberHit");
        //piggyGO.transform.position = piggyPos;
        ReturnPiggy();

        yield return new WaitForSeconds(1f);
        spriteAnim.Play("RobberWalk");
        isExiting = true;
        windowsCont.OpenWindow();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile") && !isHit)
        {
            StartCoroutine(GetHit());
        }
    }
}
