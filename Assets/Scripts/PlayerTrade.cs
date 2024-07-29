using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerTrade : MonoBehaviour
{
    [SerializeField] GameObject tradeUnit, tradeWrapper;
    [Space]
    [SerializeField] float yDecrease;
    [SerializeField] float initYDecrease = 162;

    float y;

    public void OnTrade(GameObject tradingNPC, bool enab) {
        Clear();

        if (!tradingNPC.TryGetComponent<TradesList>(out var ttf)) return;

        tradeWrapper.SetActive(enab);

        y -= initYDecrease;

        foreach (Trade trade in ttf.Trades) {
            GameObject obj = Instantiate(tradeUnit, tradeWrapper.transform, false);
            obj.GetComponent<TradesClick>().trade = trade;

            var objTexts = obj.GetComponentsInChildren<TextMeshProUGUI>();
            
            objTexts[0].text = trade.inputAmount + " " + trade.inputItem;
            objTexts[1].text = trade.outputAmount + " " + trade.outputItem;
            
            if (obj != null) obj.transform.position += Vector3.up * y;

            y -= yDecrease;
        }
    }

    void Clear() {
        foreach (Transform t in (tradeWrapper.transform)) {
            if (!t.gameObject.CompareTag("Ignore Destroy")) Destroy(t.gameObject);
        }
        y = 0;
    }
}
