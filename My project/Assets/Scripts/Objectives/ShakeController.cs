using System.Collections;
using UnityEngine;

public class ShakeController : MonoBehaviour
{

    [HideInInspector] public bool isShaking;
    [SerializeField]
    private float shakeTime = 0.2f;
    [SerializeField]
    private float shakeAmount = 0.15f;
    private float currentShakeAmount;

    Coroutine cor;
    Vector2 originalPos;

    private void Awake()
    {
        //sprite = GetComponent<GameObject>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //originalPos = sprite.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (isShaking)
            Shake();
    }

    private void Shake()
    {
        Vector2 newPos = originalPos + Random.insideUnitCircle * (/*Time.deltaTime * */currentShakeAmount);

        transform.localPosition = (Vector3)newPos;
    }

    public void SetShake( /*float time, float amount*/)
    {
        if (cor != null)
        {
            transform.localPosition = /*new Vector2(0,0)*/ originalPos;
            StopCoroutine(cor);
        }

        //originalPos = sprite.transform.localPosition;

        //shakeTime = time;
        //shakeAmount = amount;

        cor = StartCoroutine(ShakeTime());
        //Debug.Log("shake it boss " + transform.name);
    }

    private IEnumerator ShakeTime()
    {
        isShaking = true;
        currentShakeAmount = shakeAmount;
        yield return new WaitForSeconds(shakeTime / 2);
        currentShakeAmount = shakeAmount / 3;
        yield return new WaitForSeconds(shakeTime / 2);
        isShaking = false;
        //Debug.Log(originalPos);
        transform.localPosition = /*new Vector2(0,0)*/ originalPos;
    }

}
