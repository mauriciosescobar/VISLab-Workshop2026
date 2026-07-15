using UnityEngine;
using System;
using System.Diagnostics.CodeAnalysis;
public enum CoinColor
{
    RED,
    YELLOW,
    BLUE
}
[Serializable]
public struct CoinsCollected
{
    public int red, yellow, blue;
    public CoinsCollected( int red , int yellow, int blue)
    {
        this.red = red;
        this.yellow = yellow;
        this.blue = blue;
    }
}