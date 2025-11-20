using Unity.VisualScripting;
using UnityEngine;

public class Objective : MonoBehaviour
{
    [SerializeField]
    private int score = 100;
    [SerializeField]
    private int hp = 1;
    [SerializeField]
    private bool canDestroy = false;
    private bool isDestroyed = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile")) 
        {
            //Debug.Log("+ SCORE");
            GameManager.instance.ChangeScore(score);
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        hp--;
        CheckDestroyed();
    }

    private void CheckDestroyed()
    {
        if(hp >= 0)
        {
            isDestroyed = true;
            StartDestroy();
        }
    }

    private void StartDestroy()
    {
        //change sprite or disable hitbox or whatever
        if (canDestroy) 
            Destroy(gameObject);
    }
}
