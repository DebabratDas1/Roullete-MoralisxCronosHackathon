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
    public TextMeshProUGUI walletAddressText, nativeBalanceText, chipsBalanceText, chipPriceText;
    public TMP_InputField buyBalanceText, sellBalanceText;

    public TextMeshProUGUI buyLogText;


    //private int buyBalance;
    public int NumberOfChipsToBuy
    {
        get
        {
            var success = int.TryParse(buyBalanceText.text, out int requiredChips);
            if (success)
                return requiredChips;
            else
                return 0;
        }
    }
}
