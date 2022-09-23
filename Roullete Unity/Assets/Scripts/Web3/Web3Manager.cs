using Cysharp.Threading.Tasks;
using MoralisUnity;
using MoralisUnity.Platform.Objects;
using MoralisUnity.Web3Api.Models;
using Nethereum.Hex.HexTypes;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Newtonsoft.Json;
using UnityEngine;
using Newtonsoft.Json.Linq;
using System;

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


    private string userWalletAddress;

    public bool isConnected = false;
    /*public string UserWalletAddress
    {
        get
        {
            OnConnectedWalletAsync();
        }
    }*/
     private string contractAddress = "0xed70d5112f68268466D842d96d020A58ae34b959";
    // 0xeEc815Bee78923a48CA152F6C1ab6Bb89E486AED
    private string contractABI = "[{\"inputs\":[],\"name\":\"AddBalanceToContract\",\"outputs\":[],\"stateMutability\":\"payable\",\"type\":\"function\"},{\"inputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"constructor\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"value\",\"type\":\"uint256\"}],\"name\":\"Approval\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"approve\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"amt\",\"type\":\"uint256\"}],\"name\":\"bet\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"Bought\",\"type\":\"event\"},{\"inputs\":[],\"name\":\"buyTokens\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenAmount\",\"type\":\"uint256\"}],\"stateMutability\":\"payable\",\"type\":\"function\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"address\",\"name\":\"buyer\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountOfETH\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountOfTokens\",\"type\":\"uint256\"}],\"name\":\"BuyTokens\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"subtractedValue\",\"type\":\"uint256\"}],\"name\":\"decreaseAllowance\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"amt\",\"type\":\"uint256\"}],\"name\":\"getPrize\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"addedValue\",\"type\":\"uint256\"}],\"name\":\"increaseAllowance\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"previousOwner\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"newOwner\",\"type\":\"address\"}],\"name\":\"OwnershipTransferred\",\"type\":\"event\"},{\"inputs\":[],\"name\":\"renounceOwnership\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenAmountToSell\",\"type\":\"uint256\"}],\"name\":\"sellTokens\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"_price\",\"type\":\"uint256\"}],\"name\":\"SetChipsPrice\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"Sold\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"transfer\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"value\",\"type\":\"uint256\"}],\"name\":\"Transfer\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"transferFrom\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"newOwner\",\"type\":\"address\"}],\"name\":\"transferOwnership\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"}],\"name\":\"allowance\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"account\",\"type\":\"address\"}],\"name\":\"balanceOf\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"chipsValue\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"decimals\",\"outputs\":[{\"internalType\":\"uint8\",\"name\":\"\",\"type\":\"uint8\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"getChipsPrice\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"name\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"owner\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"ownerAdd\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"symbol\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"totalSupply\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"}]";
    //[{\"inputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"constructor\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"value\",\"type\":\"uint256\"}],\"name\":\"Approval\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"approve\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"amt\",\"type\":\"uint256\"}],\"name\":\"bid\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"Bought\",\"type\":\"event\"},{\"inputs\":[],\"name\":\"buyTokens\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenAmount\",\"type\":\"uint256\"}],\"stateMutability\":\"payable\",\"type\":\"function\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"address\",\"name\":\"buyer\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountOfETH\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountOfTokens\",\"type\":\"uint256\"}],\"name\":\"BuyTokens\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"subtractedValue\",\"type\":\"uint256\"}],\"name\":\"decreaseAllowance\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"amt\",\"type\":\"uint256\"}],\"name\":\"getPrize\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"addedValue\",\"type\":\"uint256\"}],\"name\":\"increaseAllowance\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"previousOwner\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"newOwner\",\"type\":\"address\"}],\"name\":\"OwnershipTransferred\",\"type\":\"event\"},{\"inputs\":[],\"name\":\"renounceOwnership\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenAmountToSell\",\"type\":\"uint256\"}],\"name\":\"sellTokens\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"_price\",\"type\":\"uint256\"}],\"name\":\"SetChipsPrice\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"Sold\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"transfer\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"value\",\"type\":\"uint256\"}],\"name\":\"Transfer\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"transferFrom\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"newOwner\",\"type\":\"address\"}],\"name\":\"transferOwnership\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"}],\"name\":\"allowance\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"account\",\"type\":\"address\"}],\"name\":\"balanceOf\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"chipsValue\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"decimals\",\"outputs\":[{\"internalType\":\"uint8\",\"name\":\"\",\"type\":\"uint8\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"getChipsPrice\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"name\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"owner\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"ownerAdd\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"symbol\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"totalSupply\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"}]
    private ChainList chainList = ChainList.cronos_testnet;
    public void OnConnectedWalletAsync()
    {
        GetSetWalletAddress();
        StartCoroutine(RefreshMarketWithDelay());
        isConnected = true;
    }

    public void OnDisConnectedWalletAsync()
    {
        GetSetWalletAddress();
        MarketUI.Instance.ClearMarketPlace();
        isConnected = false;
    }

    private async void GetSetWalletAddress()
    {
        MoralisUser user = await Moralis.GetUserAsync();
        if (user != null)
        {
            userWalletAddress = user.authData["moralisEth"]["id"].ToString();
            MarketUI.Instance.walletAddressText.text = userWalletAddress;
        }
        else
        {
            GameManager.Instance.AvailableChips = 0;
            GameManager.Instance.BetAmt = 0;
            GameManager.Instance.RewardAmount = 0;
            RewardCalculator.Instance.betReader.ClearBet();
        }
        
    }

    private async void GetNativeBalanceAsync()
    {
        NativeBalance balance = await Moralis.Web3Api.Account.GetNativeBalance(userWalletAddress.ToLower(), chainList);
        //Debug.Log($"GetNativeBalance Balance: {balance.Balance}");
        BigInteger.TryParse(balance.Balance, out BigInteger tcro);
        BigInteger unit = BigInteger.Pow(10, 18);
        float nativeBal = (float)tcro / (float )unit;
        decimal d = Decimal.Parse(nativeBal.ToString(), System.Globalization.NumberStyles.Float);
        //string formattedBal = string.Format("{ 0:00.00}", nativeBal.ToString());
        MarketUI.Instance.nativeBalanceText.text = d.ToString();
        //String.Format("{0:0.00000}", d);
    }

    /*public void FetchMarketPlaceData()
    {
        GetNativeBalanceAsync();
    }*/


    // Get chips value + Y
    // Buy chips(Chips amount) need to convert to native balance value + Y
    // Sell Buy(Chips amount) +
    // Confirm Bid(chips amount) + Y
    // Get Reward(chips amount) + Y
    // Get Native Balance + Y
    // Get Token Balance + Y


    private async UniTask<string> CallContractFunction(object[] parameters, string functionName, HexBigInteger value)
    {
        HexBigInteger gas = new HexBigInteger(300000);
        HexBigInteger gasPrice = new HexBigInteger(0);

        string resp = await Moralis.ExecuteContractFunction(contractAddress, contractABI,
            functionName, parameters,
            value, gas, gasPrice);
        return resp;

    }


    /*public async void BuyChips()
    {
        Debug.Log("Inside Buychips");
        BigInteger.TryParse(MarketUI.Instance.buyBalanceText.text, out BigInteger requiredChip);
        Debug.Log(requiredChip);
        if (requiredChip <= 0)
        {
            MarketUI.Instance.buyLogText.text = "Error : You need to buy at least 1 Chip";
            return;
        }
        object[] parameters = {

        };


        BigInteger amt = requiredChip * ChipPrice;
        HexBigInteger value = new HexBigInteger(amt);
        Debug.Log("value = " + value);

        string functionName = "buyTokens";
        Debug.Log("ABI : "+contractABI.Length);
        string resp = await CallContractFunction(parameters, functionName, value);
        Debug.Log("Contract Address : " + contractAddress);
        Debug.Log("User " + userWalletAddress);
        if (resp != null)
            Debug.Log("Successfully purchased chips");
        else
            Debug.Log("Unsuccessful transaction !");
    }*/

    public float chipPriceInToken = 0;
    private BigInteger chipPrice;
    public BigInteger ChipPrice
    {
        get
        {
            return chipPrice;
        }
        set
        {
            chipPrice = value;
            //int chipPriceInWei = chipPrice;
            chipPriceInToken = (float)chipPrice * Mathf.Pow(10, -18);
            Debug.Log("chipPriceInToken " + chipPriceInToken);
            MarketUI.Instance.chipPriceText.text = "1 chp = " + chipPriceInToken.ToString() + " TCRO";// + chipPriceInToken.ToString() + " TCRO";
        }
    }
    public async void GetChipsPrice()
    {
        object[] inputParams = new object[0];
        
        object[] outputParams = new object[1];
        outputParams[0] = new
        {
            internalType = "uint256",
            name = "",
            type = "uint256"

        };
        object[] abi = new object[1];
        abi[0] = new
        {
            inputs=inputParams,
            outputs = outputParams,
            name = "getChipsPrice",
            stateMutability = "view",
            type = "function"
        };
        RunContractDto rcd = new RunContractDto
        {
            //Abi = JsonConvert.DeserializeObject<JArray>(contractABI),
            //Params = new {account = userWalletAddress }
            Abi = abi,
            //Params = new { account = "0xa3E33AbA850A5B368a67789d4Ba062f74E5B0d39" }
            Params = new { account = userWalletAddress }
        };
        MoralisClient moralisClient = Moralis.GetClient();
    
        //string functionName = "getChipsPrice";
        string resp = await moralisClient.Web3Api.Native.RunContractFunction<string>(
            contractAddress, "getChipsPrice", rcd, chainList);
        Debug.Log(resp);
        BigInteger.TryParse(resp, out BigInteger _chipPrice);
        ChipPrice = _chipPrice;
        Debug.Log(ChipPrice);

    }


    public void RefreshMarketPlace()
    {
        if (isConnected)
        {
            GetSetWalletAddress();
            GetChipsPrice();
            GetNativeBalanceAsync();
            GetTokenBalance();
        }
        else
        {
            UIManager.Instance.ShowLogPanel("You are not signed in.");
        }
        
    }





    private async UniTask<string> CallBuyChipsFunction()
    {
        


        // Contract Function Parameters
        object[] parameters = {
        };

        // Calculate value for required chips

        BigInteger.TryParse(MarketUI.Instance.buyBalanceText.text, out BigInteger requiredChip);
        Debug.Log(requiredChip);
        if (requiredChip <= 0)
        {
            MarketUI.Instance.buyLogText.text = "Error : You need to buy at least 1 Chip";
            return null;
        }
        Debug.Log("Chip Price = " + ChipPrice);
        BigInteger amt = requiredChip * ChipPrice;
        //HexBigInteger value = new HexBigInteger(amt);
        Debug.Log("Total Price = " + amt);

        if (amt <= 0)
        {
            Debug.Log("Total Price is less than or equal to 0");
        }

        BigInteger val = BigInteger.Parse(amt.ToString());
        HexBigInteger value = new HexBigInteger(val);
        HexBigInteger gas = new HexBigInteger(300000);
        HexBigInteger gasPrice = new HexBigInteger(0);

        

        Debug.Log("value = " + value);

        string resp = await Moralis.ExecuteContractFunction(contractAddress, contractABI,
            "buyTokens", parameters,
            value, gas, gasPrice);
        Debug.Log(contractABI.Length);
        Debug.Log("resp" + resp);
        //RunContractFunction()
        if (resp == null)
            UIManager.Instance.ShowLogPanel("Transaction Unsuccessful");
        

        return resp;
    }

    public async void BuyChip()
    {
        await CallBuyChipsFunction();
        StartCoroutine(RefreshMarketWithDelay());
        
    }



    public async void GetTokenBalance()
    {
        object[] inputParams = new object[1];
        inputParams[0] = new
        {
            internalType = "address",
            name = "account",
            type = "address"
        };
        object[] outputParams = new object[1];
        outputParams[0] = new
        {
            internalType = "uint256",
            name = "",
            type = "uint256"

        };
        object[] abi = new object[1];
        abi[0] = new
        {
            inputs = inputParams,
            outputs = outputParams,
            name = "balanceOf",
            stateMutability = "view",
            type = "function"
        };
        RunContractDto rcd = new RunContractDto
        {
            
            Abi = abi,
            Params = new { account = userWalletAddress }
        };
        MoralisClient moralisClient = Moralis.GetClient();

        string functionName = "balanceOf";
        string resp = await moralisClient.Web3Api.Native.RunContractFunction<string>(
            contractAddress, functionName, rcd, chainList);
        Debug.Log(resp);
        BigInteger.TryParse(resp, out BigInteger tokenBal);
        GameManager.Instance.AvailableChips = tokenBal;

        //int.TryParse(resp, out int tokenBalance);
        MarketUI.Instance.chipsBalanceText.text = tokenBal.ToString();

    }

    public async void CallGetRewards()
    {
        string resp = await GetReward(GameManager.Instance.RewardAmount);
        if (resp != null)
        {

            StartCoroutine(RefreshMarketWithDelay());
            UIManager.Instance.ShowRewardInfoUI();
        }
        else
        {

        }
    }


    public async UniTask<string> GetReward(int _prizeAmt)
    {
        
        //USER ADDRESS CHECKING
        MoralisUser user = await Moralis.GetUserAsync();
        Debug.Log(user);
        string fromAddress = user.authData["moralisEth"]["id"].ToString();
        Debug.Log(fromAddress + "  FromAddress");

        if (fromAddress == null)
        {
            return null;
        }

        // Calculate Prize Amount

        BigInteger prizeAmt = new BigInteger(_prizeAmt);

        // Contract Function Parameters
        object[] parameters = {
            prizeAmt
        };

        

        
        HexBigInteger value = new HexBigInteger(0);
        HexBigInteger gas = new HexBigInteger(300000);
        HexBigInteger gasPrice = new HexBigInteger(0);




        string resp = await Moralis.ExecuteContractFunction(contractAddress, contractABI,
            "getPrize", parameters,
            value, gas, gasPrice);
        //Debug.Log(contractABI.Length);
        Debug.Log("resp" + resp);
        //RunContractFunction()
        if (resp == null)
            Debug.Log("Transaction Unsuccessful");
        return resp;
    }


    public async void ConfirmBet()
    {
        
        string resp = await Bet(GameManager.Instance.BetAmt);
        if (resp != null)
        {

            StartCoroutine(RefreshMarketWithDelay());
            UIManager.Instance.WillShowDiceRollUI(true);
        }
        else
        {
           UIManager.Instance.ShowLogPanel("Transaction Unsuccessful");
        }
    }

    private async UniTask<string> Bet(int _betAmt)
    {

        //USER ADDRESS CHECKING
        MoralisUser user = await Moralis.GetUserAsync();
        Debug.Log(user);
        string fromAddress = user.authData["moralisEth"]["id"].ToString();
        Debug.Log(fromAddress + "  FromAddress");

        if (fromAddress == null)
        {
            return null;
        }

        // Calculate Prize Amount

        BigInteger prizeAmt = new BigInteger(_betAmt);

        // Contract Function Parameters
        object[] parameters = {
            prizeAmt
        };




        HexBigInteger value = new HexBigInteger(0);
        HexBigInteger gas = new HexBigInteger(300000);
        HexBigInteger gasPrice = new HexBigInteger(0);




        string resp = await Moralis.ExecuteContractFunction(contractAddress, contractABI,
            "bet", parameters,
            value, gas, gasPrice);
        //Debug.Log(contractABI.Length);
        Debug.Log("resp" + resp);
        //RunContractFunction()
        if (resp == null)
            Debug.Log("Transaction Unsuccessful");
        
        return resp;
    }


    public IEnumerator RefreshMarketWithDelay()
    {
        yield return new WaitForSeconds(6f);
        RefreshMarketPlace();
    }



    public async UniTask<bool> IsConnected()
    {
        //string fromAddress = null;
        //USER ADDRESS CHECKING
        MoralisUser user = await Moralis.GetUserAsync();
        Debug.Log(user);
        //fromAddress = user.authData["moralisEth"]["id"].ToString();
        if (user != null)
            return true;
        else
            return false;
    }




    private async UniTask<string> CallSellChipsFunction()
    {
       /* {
            "inputs": [
    
            {
                "internalType": "uint256",
				"name": "tokenAmountToSell",
				"type": "uint256"
    
            }
		],
		"name": "sellTokens",
		"outputs": [],
		"stateMutability": "nonpayable",
		"type": "function"

    },*/


        

        // Calculate value for required chips

        BigInteger.TryParse(MarketUI.Instance.sellBalanceText.text, out BigInteger requiredChip);
        Debug.Log(requiredChip);
        if (requiredChip <= 0)
        {
            MarketUI.Instance.sellLogText.text = "Error : You need to sell at least 1 Chip";
            return null;
        }

        Debug.Log("required chip = " + requiredChip);
        // Contract Function Parameters
        object[] parameters = {
            requiredChip
        };

        //BigInteger val = BigInteger.Parse(amt.ToString());
        HexBigInteger value = new HexBigInteger(0);
        HexBigInteger gas = new HexBigInteger(300000);
        HexBigInteger gasPrice = new HexBigInteger(0);



        //Debug.Log("value = " + value);

        string resp = await Moralis.ExecuteContractFunction(contractAddress, contractABI,
            "sellTokens", parameters,
            value, gas, gasPrice);
        //Debug.Log(contractABI.Length);
        Debug.Log("resp" + resp);
        //RunContractFunction()
        if (resp == null)
            UIManager.Instance.ShowLogPanel("Transaction Unsuccessful");


        return resp;
    }

    public async void SellChip()
    {
        await CallSellChipsFunction();
        StartCoroutine(RefreshMarketWithDelay());

    }


}




//[{\"inputs\":[],\"name\":\"AddBalanceToContract\",\"outputs\":[],\"stateMutability\":\"payable\",\"type\":\"function\"},{\"inputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"constructor\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"value\",\"type\":\"uint256\"}],\"name\":\"Approval\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"approve\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"amt\",\"type\":\"uint256\"}],\"name\":\"bid\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"Bought\",\"type\":\"event\"},{\"inputs\":[],\"name\":\"buyTokens\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenAmount\",\"type\":\"uint256\"}],\"stateMutability\":\"payable\",\"type\":\"function\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"address\",\"name\":\"buyer\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountOfETH\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountOfTokens\",\"type\":\"uint256\"}],\"name\":\"BuyTokens\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"subtractedValue\",\"type\":\"uint256\"}],\"name\":\"decreaseAllowance\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"amt\",\"type\":\"uint256\"}],\"name\":\"getPrize\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"addedValue\",\"type\":\"uint256\"}],\"name\":\"increaseAllowance\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"previousOwner\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"newOwner\",\"type\":\"address\"}],\"name\":\"OwnershipTransferred\",\"type\":\"event\"},{\"inputs\":[],\"name\":\"renounceOwnership\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenAmountToSell\",\"type\":\"uint256\"}],\"name\":\"sellTokens\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"_price\",\"type\":\"uint256\"}],\"name\":\"SetChipsPrice\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"Sold\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"transfer\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"value\",\"type\":\"uint256\"}],\"name\":\"Transfer\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"transferFrom\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"newOwner\",\"type\":\"address\"}],\"name\":\"transferOwnership\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"}],\"name\":\"allowance\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"account\",\"type\":\"address\"}],\"name\":\"balanceOf\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"chipsValue\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"decimals\",\"outputs\":[{\"internalType\":\"uint8\",\"name\":\"\",\"type\":\"uint8\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"getChipsPrice\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"name\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"owner\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"ownerAdd\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"symbol\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"totalSupply\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"}]
//0x6b82a6C67F63aec3Df91F71cC974d33fDB111764