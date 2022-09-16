using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    private void Awake()
    {
        if(Instance!=null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    [SerializeField] private GameObject infoHomeUI, payoutsUI, predictionUI;


    public void InfoHomeUI()
    {
        infoHomeUI.SetActive(true);
        payoutsUI.SetActive(false);
        predictionUI.SetActive(false);
    }
    public void PayoutsInfoUI()
    {
        infoHomeUI.SetActive(false);
        payoutsUI.SetActive(true);
        predictionUI.SetActive(false);
    }
    public void PredictionInfoUI()
    {
        infoHomeUI.SetActive(false);
        payoutsUI.SetActive(false);
        predictionUI.SetActive(true);
    }


    [SerializeField] private TextMeshProUGUI betAmt, winAmt, netWinAmt, diceOutcome;
    [SerializeField] private GameObject rewardInfoUI;
    public void ShowRewardInfoUI()
    {
        betAmt.text = GameManager.Instance.BetAmt.ToString();
        winAmt.text = GameManager.Instance.RewardAmount.ToString();
        netWinAmt.text = GameManager.Instance.NetWin.ToString();
        diceOutcome.text = GameManager.Instance.DiceOutcome.ToString();
        rewardInfoUI.SetActive(true);
    }

    public void HideRewardInfoUI()
    {
        rewardInfoUI.SetActive(false);
    }


    [SerializeField] private GameObject gamePlayUI,marketplaceUI;

    public void ShowGamePlayUI()
    {
        gamePlayUI.SetActive(true);
        marketplaceUI.SetActive(false);
    }
    public void ShowMarketplaceUI()
    {
        gamePlayUI.SetActive(false);
        marketplaceUI.SetActive(true);
    }

}
