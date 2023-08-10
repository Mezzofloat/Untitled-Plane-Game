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
}
