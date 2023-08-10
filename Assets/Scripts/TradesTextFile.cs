using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradesTextFile : MonoBehaviour
{
    [SerializeField] List<Trade> trades = new List<Trade>();

    public List<Trade> Trades => trades;
}
