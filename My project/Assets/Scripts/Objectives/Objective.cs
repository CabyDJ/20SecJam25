using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class Objective : MonoBehaviour
{
    [SerializeField]
    public int score = 100; 
    [SerializeField]
    public int scoreOnBreak = 0;
    [SerializeField]
    private int hp = 1;
    [SerializeField]
    private bool canDestroy = false;
    private bool isDestroyed = false;
    [SerializeField]
    private GameObject PointsGO;
    [SerializeField]
    private GameObject HitGO;

    private ShakeController shakeCont;

    private void Awake()
    {
        shakeCont = GetComponentInChildren<ShakeController>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void ShowHitEffects(Vector3 pos)
    {
        //GameObject go = Instantiate(HitGO);
        //go.transform.position = pos;

        GameObject pointsGO = Instantiate(PointsGO);
        pointsGO.transform.position = pos;
        ShowPoints sp = pointsGO.GetComponent<ShowPoints>();
        sp.SetPoints(score);

        shakeCont.SetShake();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile")) 
        {
            //Debug.Log("+ SCORE");
            GameManager.instance.ChangeScore(score);
            ShowHitEffects(collision.gameObject.transform.position);
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        hp--;
        //score = (int)(score * 0.9);

        if (hp == 1 && scoreOnBreak != 0)
        {
            score = scoreOnBreak;
        }

        if(score < 0)
            score = 0;

        CheckDestroyed();
    }

    private void CheckDestroyed()
    {
        if(hp <= 0 && !isDestroyed)
        {
            isDestroyed = true;
            StartDestroy();
        }
    }

    private void StartDestroy()
    {
        score = score / 4;
        //change sprite or disable hitbox or whatever
        if (canDestroy) 
            Destroy(gameObject);
    }
}
