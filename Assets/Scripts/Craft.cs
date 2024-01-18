using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craft : MonoBehaviour
{
    [SerializeField] List<Transform> craftingTables;

    Transform nearestCraftingTable;

    void OnInteract() {
        nearestCraftingTable = craftingTables[0];
        foreach (Transform table in craftingTables)
        {
            if ((table.position - transform.position).sqrMagnitude < (nearestCraftingTable.position - transform.position).sqrMagnitude) 
                nearestCraftingTable = table;
        }

        Debug.Log("got here!");
    }
}
