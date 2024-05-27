using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Craft : MonoBehaviour
{
    [SerializeField] List<Transform> craftingTables;
    [SerializeField] GameObject tradeUnit, tradeWrapper;

    Transform nearestCraftingTable;
    float y;

    void OnInteract() {
        nearestCraftingTable = craftingTables[0];
        foreach (Transform table in craftingTables)
        {
            if ((table.position - transform.position).sqrMagnitude < (nearestCraftingTable.position - transform.position).sqrMagnitude) 
                nearestCraftingTable = table;
        }
    }

    void OnTrade(GameObject tradingNPC, bool enab) {
        Clear();

        if (!tradingNPC.TryGetComponent<TradesList>(out var ttf)) return;

        tradeWrapper.SetActive(enab);

        foreach (Trade trade in ttf.Trades) {
            var obj = Instantiate(tradeUnit, tradeWrapper.transform);
            var objTexts = obj.GetComponentsInChildren<TextMeshProUGUI>();
            
            objTexts[0].text = trade.inputAmount.ToString() + " " + trade.inputItem;
            objTexts[1].text = trade.outputAmount.ToString() + " " + trade.outputItem;
            
            if (obj != null) obj.transform.position += Vector3.up * y;
            y -= 120;
        }
    }

    void Clear() {
        foreach (Transform t in tradeWrapper.transform) {
            if (!t.gameObject.CompareTag("Ignore Destroy")) Destroy(t.gameObject);
        }
        y = 0;
    }
}
