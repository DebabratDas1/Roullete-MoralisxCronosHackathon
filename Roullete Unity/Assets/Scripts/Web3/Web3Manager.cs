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
    /*public string UserWalletAddress
    {
        get
        {
            OnConnectedWalletAsync();
        }
    }*/
     private string contractAddress = "0xD1Da3eB825224F779aa21D9746e022819d1b2163";
    private string contractABI = "[{\"inputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"constructor\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"value\",\"type\":\"uint256\"}],\"name\":\"Approval\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"approve\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"amt\",\"type\":\"uint256\"}],\"name\":\"bid\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"Bought\",\"type\":\"event\"},{\"inputs\":[],\"name\":\"buyTokens\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenAmount\",\"type\":\"uint256\"}],\"stateMutability\":\"payable\",\"type\":\"function\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"address\",\"name\":\"buyer\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountOfETH\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountOfTokens\",\"type\":\"uint256\"}],\"name\":\"BuyTokens\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"subtractedValue\",\"type\":\"uint256\"}],\"name\":\"decreaseAllowance\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"amt\",\"type\":\"uint256\"}],\"name\":\"getPrize\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"addedValue\",\"type\":\"uint256\"}],\"name\":\"increaseAllowance\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"previousOwner\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"newOwner\",\"type\":\"address\"}],\"name\":\"OwnershipTransferred\",\"type\":\"event\"},{\"inputs\":[],\"name\":\"renounceOwnership\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenAmountToSell\",\"type\":\"uint256\"}],\"name\":\"sellTokens\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"_price\",\"type\":\"uint256\"}],\"name\":\"SetChipsPrice\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"Sold\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"transfer\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"value\",\"type\":\"uint256\"}],\"name\":\"Transfer\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"transferFrom\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"newOwner\",\"type\":\"address\"}],\"name\":\"transferOwnership\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"}],\"name\":\"allowance\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"account\",\"type\":\"address\"}],\"name\":\"balanceOf\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"chipsValue\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"decimals\",\"outputs\":[{\"internalType\":\"uint8\",\"name\":\"\",\"type\":\"uint8\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"getChipsPrice\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"name\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"owner\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"ownerAdd\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"symbol\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"totalSupply\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"}]";
    private ChainList chainList = ChainList.mumbai;
    public void OnConnectedWalletAsync()
    {
        GetSetWalletAddress();
        FetchMarketPlaceData();
    }

    private async void GetSetWalletAddress()
    {
        MoralisUser user = await Moralis.GetUserAsync();
        userWalletAddress = user.authData["moralisEth"]["id"].ToString();
        MarketUI.Instance.walletAddressText.text = userWalletAddress;
    }

    private async void GetNativeBalanceAsync()
    {
        NativeBalance balance = await Moralis.Web3Api.Account.GetNativeBalance(userWalletAddress.ToLower(), chainList);
        Debug.Log($"GetNativeBalance Balance: {balance.Balance}");
        MarketUI.Instance.nativeBalanceText.text = balance.Balance;
    }

    public void FetchMarketPlaceData()
    {
        GetNativeBalanceAsync();
    }


    // Get chips value + Y
    // Buy chips(Chips amount) need to convert to native balance value + Y
    // Sell Buy(Chips amount) +
    // Confirm Bid(chips amount) +
    // Get Reward(chips amount) +
    // Get Native Balance + Y
    // Get Token Balance +


    private async UniTask<string> CallContractFunction(object[] parameters, string functionName, HexBigInteger value)
    {
        HexBigInteger gas = new HexBigInteger(3000000);
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
            int chipPriceInWei = (int)chipPrice;
            float chipPriceInToken = (float)chipPrice * Mathf.Pow(10, -18);
            MarketUI.Instance.chipPriceText.text = "1 CHP price = " + chipPriceInWei.ToString() + " wei = " + chipPriceInToken.ToString() + " TCRO";
        }
    }
    public async void GetChipsPrice()
    {
        object[] inputParams = new object[0];
        /*inputParams[0] = new
        {

        };*/
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
        int.TryParse(resp, out int _chipPrice);
        ChipPrice = _chipPrice;

    }


    public void RefreshMarketPlace()
    {
        GetSetWalletAddress();
        GetChipsPrice();
        GetNativeBalanceAsync();
        GetTokenBalance();
    }





    private async UniTask<string> CallBuyChipsFunction()
    {
        //USER ADDRESS CHECKING
        MoralisUser user = await Moralis.GetUserAsync();
        Debug.Log(user);
        string fromAddress = user.authData["moralisEth"]["id"].ToString();
        Debug.Log(fromAddress + "  FromAddress");


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
        HexBigInteger gas = new HexBigInteger(3000000);
        HexBigInteger gasPrice = new HexBigInteger(0);

        

        Debug.Log("value = " + value);

        string resp = await Moralis.ExecuteContractFunction(contractAddress, contractABI,
            "buyTokens", parameters,
            value, gas, gasPrice);
        Debug.Log(contractABI.Length);
        Debug.Log("resp" + resp);
        //RunContractFunction()
        if (resp == null)
            Debug.Log("Transaction Unsuccessful");
        return resp;
    }

    public async void BuyChip()
    {
        await CallBuyChipsFunction();
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
        //int.TryParse(resp, out int tokenBalance);
        MarketUI.Instance.chipsBalanceText.text = tokenBal.ToString();

    }

    /*public async void CallGetRewards()
    {
        await GetReward(123);
    }*/


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
        HexBigInteger gas = new HexBigInteger(3000000);
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


    public async UniTask<string> Bet(int _prizeAmt)
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
        HexBigInteger gas = new HexBigInteger(3000000);
        HexBigInteger gasPrice = new HexBigInteger(0);




        string resp = await Moralis.ExecuteContractFunction(contractAddress, contractABI,
            "bid", parameters,
            value, gas, gasPrice);
        //Debug.Log(contractABI.Length);
        Debug.Log("resp" + resp);
        //RunContractFunction()
        if (resp == null)
            Debug.Log("Transaction Unsuccessful");
        return resp;
    }


}
