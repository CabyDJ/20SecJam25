using UnityEngine;

public class WindowController : MonoBehaviour
{
    private Objective objective;

    [SerializeField]
    private SpriteRenderer rightSpriteRenderer;
    [SerializeField]
    private SpriteRenderer leftSpriteRenderer;
    [SerializeField]
    private Sprite rightDamageSprite;
    [SerializeField]
    private Sprite leftDamageSprite;

    private void Awake()
    {
        objective = GetComponent<Objective>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
