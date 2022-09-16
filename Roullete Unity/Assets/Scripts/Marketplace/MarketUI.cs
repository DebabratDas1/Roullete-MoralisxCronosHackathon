using TMPro;
using UnityEngine;

public class MarketUI : MonoBehaviour
{
    public static MarketUI Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }
    public TextMeshProUGUI walletAddressText, nativeBalanceText, chipsBalanceText;
    public TMP_InputField buyBalanceText, sellBalanceText;
}
