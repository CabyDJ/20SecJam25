using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class DoorController : MonoBehaviour
{
    [SerializeField]
    private Objective objective;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private GameObject objectiveGuy;

    [SerializeField]
    private Animator personAnim;
    [SerializeField]
    private GameObject HurtBoxGO;

    private void Start()
    {
        InvokeRepeating(nameof(CheckBroken), 1, 1f);
    }

    private void OpenDoor()
    {
        anim.enabled = true;
        anim.Play("DoorOpen"); 
        StartCoroutine(CloseDelay());
    }

    public void CloseDoor()
    {
        anim.Play("DoorClose");
        personAnim.Play("DoorPersonLeave");
        //anim.enabled = false;
    }

    private void CheckBroken()
    {
        if (objective.isDestroyed)
        {
            CancelInvoke(nameof(CheckBroken));
            StartCoroutine(OpenDelay());
        }
    }

    private IEnumerator OpenDelay()
    {
        yield return new WaitForSeconds(4f);
        //Time.timeScale = 0.1f;
        OpenDoor();
    }

    private IEnumerator CloseDelay()
    {
        yield return new WaitForSeconds(5f); //close when it gets a hit instead of timed
        //CloseDoor();
    }

    private void SpawnObjectiveGuy()
    {
        objectiveGuy.SetActive(true);
    }
    private void HideObjectiveGuy()
    {
        objectiveGuy.SetActive(false);
    }

    private void StartDamage()
    {
        HurtBoxGO.SetActive(true);
    }

    private void StopDamage()
    {
        HurtBoxGO.SetActive(false);
    }
}
