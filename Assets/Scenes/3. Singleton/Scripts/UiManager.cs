using System.Drawing;
using UnityEngine;
using System;
using TMPro;

public class UiManager : MonoBehaviour
{
    // The public static property that other scripts access, it's a singleton
    public static UiManager Instance { get; private set; } 
    [SerializeField] private TMP_Text ui;
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

    public void Update()
    {
        CoinsCollected coinsCollected = CoinCounter.Instance.GetCoinsCollected();
        ui.text = $"Moedas Coletadas:\n  Amarela: {coinsCollected.yellow}\n  Vermelha: {coinsCollected.red}\n  Blue: {coinsCollected.blue}";
    }
}