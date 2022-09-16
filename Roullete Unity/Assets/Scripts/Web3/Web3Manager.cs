using MoralisUnity;
using MoralisUnity.Platform.Objects;
using MoralisUnity.Web3Api.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Web3Manager : MonoBehaviour
{
    public static Web3Manager Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }


    public string userWalletAddress;

    public async void OnConnectedWalletAsync()
    {
        MoralisUser user = await Moralis.GetUserAsync();
        userWalletAddress = user.authData["moralisEth"]["id"].ToString();
        MarketUI.Instance.walletAddressText.text = userWalletAddress;
        FetchMarketPlaceData();
    }

    private async void GetNativeBalanceAsync()
    {
        NativeBalance balance = await Moralis.Web3Api.Account.GetNativeBalance(userWalletAddress.ToLower(), ChainList.cronos_testnet);
        Debug.Log($"GetNativeBalance Balance: {balance.Balance}");
        MarketUI.Instance.nativeBalanceText.text = balance.Balance;
    }

    public void FetchMarketPlaceData()
    {
        GetNativeBalanceAsync();
    }
}
