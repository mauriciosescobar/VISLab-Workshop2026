using System.Drawing;
using UnityEngine;
using System;


public class CoinCounter : MonoBehaviour
{
    // The public static property that other scripts access, it's a singleton
    public static CoinCounter Instance { get; private set; } 
    [SerializeField] private CoinsCollected coinsCollected = new CoinsCollected(0,0,0);
    private void Awake()
    {
        // Enforce the Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Delete duplicate instances
            return;
        }
        Instance = this; 
    }

    public void CoinCollected( CoinColor color)
    {
        switch (color)
        {
            case CoinColor.RED:
                coinsCollected.red +=1;
                break;
            case CoinColor.YELLOW:
                coinsCollected.yellow +=1;
                break;
            case CoinColor.BLUE:
                coinsCollected.blue +=1;
                break;
        }
    }

    public CoinsCollected GetCoinsCollected()
    {
        return coinsCollected;
    }
}