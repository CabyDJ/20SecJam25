using UnityEngine;

[CreateAssetMenu(fileName = "UndergrounTableSOScript", menuName = "Scriptable Objects/UndergrounTableSOScript")]
public class UndergrounTableSOScript : ScriptableObject
{
    public int tableMaxNum = 99;
    public UndergroundItemsSOScript[] items;
}
