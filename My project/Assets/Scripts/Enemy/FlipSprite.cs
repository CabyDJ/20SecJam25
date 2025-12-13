using UnityEngine;

public class FlipSprite : MonoBehaviour
{
    Enemy enemy;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckDirection();
    }

    private void CheckDirection()
    {
        if (enemy.moveDir.x < 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }
}
