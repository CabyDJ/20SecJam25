using System;
using UnityEngine;

public class DemonSpawnCont : MonoBehaviour
{
    [SerializeField]
    GameObject[] demonitos;
    int num = 0;

    private bool even;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnDemonito()
    {
        //spawnlogic

        //if even rotate object to right

        if(num < demonitos.Length)
        {
            demonitos[num].SetActive(true);
            num++;
        }
    }
}
