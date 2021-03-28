using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> cells;
    public Item[] items;

    private void Start()
    {
        AddItemsIndex();
    }
    private void AddItemsIndex()
    {
        int count = 0;
        for (int i = 0; i < items.Length - 1; i++)
        {
            items[i] = transform.GetChild(count++).GetComponent<Item>();
            items[i].indexI = i;
        }
    }
}
