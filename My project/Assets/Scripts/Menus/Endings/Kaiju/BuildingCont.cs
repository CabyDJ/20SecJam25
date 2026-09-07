using UnityEngine;

public class BuildingCont : MonoBehaviour
{
    [SerializeField]
    private BuildingsController BCont;

    private void CheckTransition()
    {
        BCont.CheckTransition();
    }

    private void FinishedTransition()
    {
        BCont.NormalBuildings();
    }
}
