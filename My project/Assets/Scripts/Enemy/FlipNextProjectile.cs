using UnityEngine;

public class FlipNextProjectile : MonoBehaviour
{
    Enemy enemy;
    Vector2 originalPos;
    Vector2 originalPosLeft;

    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalPos = transform.localPosition;
        originalPosLeft = new Vector2( -transform.localPosition.x, transform.localPosition.y);
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
            //spriteRenderer.flipX = false;
            transform.localPosition = originalPos;
        }
        else
        {
            //spriteRenderer.flipX = true;
            transform.localPosition = originalPosLeft;
        }
    }
}
