using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Rendering.CameraUI;

public class UndergroundController : MonoBehaviour
{
    [Serializable]
    public class UndergroundItem
    {
        public UndergroundItemsSOScript itemSO;
        public int weight;

        //public UndergroundItem(int min, int max)
        //{
        //    this.min = min;
        //    this.max = max;
        //}
    }

    [SerializeField]
    private List<UndergroundItem> itemsList;
    [SerializeField]
    private UndergroundItem[] items;
    [SerializeField]
    private Transform itemPositions;
    private List<Transform> itemPositionsList = new List<Transform>();
    [SerializeField]
    private int generateItemsNum = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Transform item in itemPositions)
        {
            itemPositionsList.Add(item);
        }

        StartSelection();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SelectRandomSpots()
    {
        while (itemPositionsList.Count > generateItemsNum)
        {
            int removeIndex = UnityEngine.Random.Range(0, itemPositionsList.Count);
            itemPositionsList.RemoveAt(removeIndex);
        }
    }

    private void StartSelection()
    {
        SelectRandomSpots();

        foreach (Transform position in itemPositionsList)
        {
            UndergroundItemsSOScript rndItem = GenerateRandom();

            position.GetComponent<SpriteRenderer>().sprite = rndItem.sprite;
            //position.GetComponent<Animator>().Play(rndItem.animation.name);
        }
    }

    private UndergroundItemsSOScript GenerateRandom()
    {
        var totalWeight = 0;
        UndergroundItemsSOScript rndItem = null;

        foreach (UndergroundItem item in itemsList)
        {
            totalWeight += item.weight;
        }

        var rndWeightValue = UnityEngine.Random.Range(1, totalWeight + 1);

        var processedWeight = 0;
        //foreach (UndergroundItem item in items)
        //{
        //    processedWeight += item.weight;
        //    if (rndWeightValue <= processedWeight)
        //    {
        //        rndItem = item.itemSO;
        //        break;
        //    }
        //}

        for (int i = 0; i < itemsList.Count; i++)
        {
            processedWeight += itemsList[i].weight;
            if (rndWeightValue <= processedWeight)
            {
                rndItem = itemsList[i].itemSO;
                itemsList.Remove(itemsList[i]);
                break;
            }
        }

        return rndItem;
    }
}
