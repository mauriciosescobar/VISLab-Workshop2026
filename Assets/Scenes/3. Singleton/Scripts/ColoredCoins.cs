using UnityEngine;

public class ColoredCoins : MonoBehaviour
{

    public CoinColor coinColor = CoinColor.YELLOW;

    private void Start()
    {
        Renderer myRenderer = GetComponent<Renderer>();
        switch (coinColor)
        {
            case CoinColor.RED:
                myRenderer.material.SetColor("_BaseColor", Color.red);
                break;
            case CoinColor.YELLOW:
                myRenderer.material.SetColor("_BaseColor", Color.yellow);
                break;
            case CoinColor.BLUE:
                myRenderer.material.SetColor("_BaseColor", Color.blue);
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.SetActive(false);
        CoinCounter.Instance.CoinCollected(coinColor);
    }
}
