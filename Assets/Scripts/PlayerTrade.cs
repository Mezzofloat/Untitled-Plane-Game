using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerTrade : MonoBehaviour
{
    [SerializeField] GameObject tradeUnit, tradeWrapper;

    float y;

    public void OnTrade(GameObject tradingNPC, bool enab) {
        Clear();

        if (!tradingNPC.TryGetComponent<TradesList>(out var ttf)) return;

        tradeWrapper.SetActive(enab);

        foreach (Trade trade in ttf.Trades) {
            var obj = Instantiate(tradeUnit, tradeWrapper.transform);
            var objTexts = obj.GetComponentsInChildren<TextMeshProUGUI>();
            
            objTexts[0].text = trade.input;
            objTexts[1].text = trade.output;
            
            if (obj != null) obj.transform.position += Vector3.up * y;
            y -= 135;
        }
    }

    void Clear() {
        foreach (Transform t in (tradeWrapper.transform)) {
            if (!t.gameObject.CompareTag("Ignore Destroy")) Destroy(t.gameObject);
        }
        y = 0;
    }
}
