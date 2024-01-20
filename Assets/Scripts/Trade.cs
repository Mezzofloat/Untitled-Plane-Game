using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Trade
{
    public int inputAmount;
    public int outputAmount;

    public string inputItem;
    public string outputItem;

    public Trade(int InputAmount, string InputItem, int OutputAmount, string OutputItem) {
        inputAmount = InputAmount;
        inputItem = InputItem;

        outputAmount = OutputAmount;
        outputItem = OutputItem;
    }
    public override string ToString() => $"{inputAmount} {inputItem} for {outputAmount} {outputItem}";

    public override bool Equals(object obj)
    {
        if (obj == null && this == null) return true;
        else if (obj == null || this == null) return false;

        if (obj is not Trade) return false;

        return Equals((Trade)obj);
    }

    public bool Equals(Trade obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
    
        return inputAmount.Equals(obj.inputAmount) && inputItem.Equals(obj.outputItem) && outputAmount.Equals(obj.outputAmount) && outputItem.Equals(obj.outputItem);
    }

    public override int GetHashCode()
    {
        return inputAmount * inputItem.GetHashCode() ^ (outputAmount * outputItem.GetHashCode() << 1);
    }
}
