using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradesList : MonoBehaviour
{
    [SerializeField] List<Trade> trades = new() {
        new Trade("2 Shells", "4 Pearls"),
        new Trade("4 Pearls", "2 Shells")   
    };
    
    public List<Trade> Trades => trades;
}
