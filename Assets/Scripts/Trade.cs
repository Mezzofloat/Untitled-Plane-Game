using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Trade
{
    public string input;
    public string output;

    public Trade(string Input, string Output) {
        input = Input;
        output = Output;
    }
    public override string ToString() => $"{input} for {output}";

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
    
        return input.Equals(obj.input) && output.Equals(obj.output);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
