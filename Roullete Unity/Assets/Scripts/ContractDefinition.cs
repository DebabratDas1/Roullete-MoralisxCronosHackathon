using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

public class ContractDefinition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


public class BuySell1Console
{
    public static async Task Main()
    {
        var url = "http://testchain.nethereum.com:8545";
        //var url = "https://mainnet.infura.io";
        var privateKey = "0x7580e7fb49df1c861f0050fae31c2224c6aba908e116b8da44ee8cd927b990b0";
        var account = new Nethereum.Web3.Accounts.Account(privateKey);
        var web3 = new Web3(account, url);
        var contractAddress = "";
        /* Deployment 
       var buySell1Deployment = new BuySell1Deployment();

       var transactionReceiptDeployment = await web3.Eth.GetContractDeploymentHandler<BuySell1Deployment>().SendRequestAndWaitForReceiptAsync(buySell1Deployment);
       var contractAddress = transactionReceiptDeployment.ContractAddress;
        */
        var contractHandler = web3.Eth.GetContractHandler(contractAddress);

        /** Function: addressThis**/
        /*
        var addressThisFunctionReturn = await contractHandler.QueryAsync<AddressThisFunction, string>();
        */


        /** Function: allowance**/
        /*
        var allowanceFunction = new AllowanceFunction();
        allowanceFunction.Owner = owner;
        allowanceFunction.Spender = spender;
        var allowanceFunctionReturn = await contractHandler.QueryAsync<AllowanceFunction, BigInteger>(allowanceFunction);
        */


        /** Function: approve**/
        /*
        var approveFunction = new ApproveFunction();
        approveFunction.Spender = spender;
        approveFunction.Amount = amount;
        var approveFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(approveFunction);
        */


        /** Function: balanceOf**/
        /*
        var balanceOfFunction = new BalanceOfFunction();
        balanceOfFunction.Account = account;
        var balanceOfFunctionReturn = await contractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction);
        */


        /** Function: balanceOfdeployer**/

        var balanceOfdeployerFunctionReturn = await contractHandler.QueryAsync<BalanceOfdeployerFunction, BigInteger>();



        /** Function: bid**/
        /*
        var bidFunction = new BidFunction();
        bidFunction.Amt = amt;
        var bidFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(bidFunction);
        */


        /** Function: buy**/
        /*
        var buyFunction = new BuyFunction();
        buyFunction.AmountTobuy = amountTobuy;
        var buyFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(buyFunction);
        */


        /** Function: buyTokens**/
        /*
        var buyTokensFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync<BuyTokensFunction>();
        */


        /** Function: decimals**/
        /*
        var decimalsFunctionReturn = await contractHandler.QueryAsync<DecimalsFunction, byte>();
        */


        /** Function: decreaseAllowance**/
        /*
        var decreaseAllowanceFunction = new DecreaseAllowanceFunction();
        decreaseAllowanceFunction.Spender = spender;
        decreaseAllowanceFunction.SubtractedValue = subtractedValue;
        var decreaseAllowanceFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(decreaseAllowanceFunction);
        */


        /** Function: deployerAddress**/
        /*
        var deployerAddressFunctionReturn = await contractHandler.QueryAsync<DeployerAddressFunction, string>();
        */


        /** Function: getMsgSender**/
        /*
        var getMsgSenderFunctionReturn = await contractHandler.QueryAsync<GetMsgSenderFunction, string>();
        */


        /** Function: getOwner**/
        /*
        var getOwnerFunctionReturn = await contractHandler.QueryAsync<GetOwnerFunction, string>();
        */


        /** Function: getPrize**/
        /*
        var getPrizeFunction = new GetPrizeFunction();
        getPrizeFunction.Amt = amt;
        var getPrizeFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(getPrizeFunction);
        */


        /** Function: increaseAllowance**/
        /*
        var increaseAllowanceFunction = new IncreaseAllowanceFunction();
        increaseAllowanceFunction.Spender = spender;
        increaseAllowanceFunction.AddedValue = addedValue;
        var increaseAllowanceFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(increaseAllowanceFunction);
        */


        /** Function: name**/
        /*
        var nameFunctionReturn = await contractHandler.QueryAsync<NameFunction, string>();
        */


        /** Function: owner**/
        /*
        var ownerFunctionReturn = await contractHandler.QueryAsync<OwnerFunction, string>();
        */


        /** Function: sell**/
        /*
        var sellFunction = new SellFunction();
        sellFunction.Amount = amount;
        var sellFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(sellFunction);
        */


        /** Function: sellTokens**/
        /*
        var sellTokensFunction = new SellTokensFunction();
        sellTokensFunction.TokenAmountToSell = tokenAmountToSell;
        var sellTokensFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(sellTokensFunction);
        */


        /** Function: symbol**/
        /*
        var symbolFunctionReturn = await contractHandler.QueryAsync<SymbolFunction, string>();
        */


        /** Function: tokensPerEth**/
        /*
        var tokensPerEthFunctionReturn = await contractHandler.QueryAsync<TokensPerEthFunction, BigInteger>();
        */


        /** Function: totalSupply**/
        /*
        var totalSupplyFunctionReturn = await contractHandler.QueryAsync<TotalSupplyFunction, BigInteger>();
        */


        /** Function: transfer**/
        /*
        var transferFunction = new TransferFunction();
        transferFunction.To = to;
        transferFunction.Amount = amount;
        var transferFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(transferFunction);
        */


        /** Function: transferFrom**/
        /*
        var transferFromFunction = new TransferFromFunction();
        transferFromFunction.From = from;
        transferFromFunction.To = to;
        transferFromFunction.Amount = amount;
        var transferFromFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction);
        */
    }

}

public partial class BuySell1Deployment : BuySell1DeploymentBase
{
    public BuySell1Deployment() : base(BYTECODE) { }
    public BuySell1Deployment(string byteCode) : base(byteCode) { }
}

public class BuySell1DeploymentBase : ContractDeploymentMessage
{
    public static string BYTECODE = "";
    public BuySell1DeploymentBase() : base(BYTECODE) { }
    public BuySell1DeploymentBase(string byteCode) : base(byteCode) { }

}

public partial class AddressThisFunction : AddressThisFunctionBase { }

[Function("addressThis", "address")]
public class AddressThisFunctionBase : FunctionMessage
{

}

public partial class AllowanceFunction : AllowanceFunctionBase { }

[Function("allowance", "uint256")]
public class AllowanceFunctionBase : FunctionMessage
{
    [Parameter("address", "owner", 1)]
    public virtual string Owner { get; set; }
    [Parameter("address", "spender", 2)]
    public virtual string Spender { get; set; }
}

public partial class ApproveFunction : ApproveFunctionBase { }

[Function("approve", "bool")]
public class ApproveFunctionBase : FunctionMessage
{
    [Parameter("address", "spender", 1)]
    public virtual string Spender { get; set; }
    [Parameter("uint256", "amount", 2)]
    public virtual BigInteger Amount { get; set; }
}

public partial class BalanceOfFunction : BalanceOfFunctionBase { }

[Function("balanceOf", "uint256")]
public class BalanceOfFunctionBase : FunctionMessage
{
    [Parameter("address", "account", 1)]
    public virtual string Account { get; set; }
}

public partial class BalanceOfdeployerFunction : BalanceOfdeployerFunctionBase { }

[Function("balanceOfdeployer", "uint256")]
public class BalanceOfdeployerFunctionBase : FunctionMessage
{

}

public partial class BidFunction : BidFunctionBase { }

[Function("bid", "bool")]
public class BidFunctionBase : FunctionMessage
{
    [Parameter("uint256", "amt", 1)]
    public virtual BigInteger Amt { get; set; }
}

public partial class BuyFunction : BuyFunctionBase { }

[Function("buy")]
public class BuyFunctionBase : FunctionMessage
{
    [Parameter("uint256", "amountTobuy", 1)]
    public virtual BigInteger AmountTobuy { get; set; }
}

public partial class BuyTokensFunction : BuyTokensFunctionBase { }

[Function("buyTokens", "uint256")]
public class BuyTokensFunctionBase : FunctionMessage
{

}

public partial class DecimalsFunction : DecimalsFunctionBase { }

[Function("decimals", "uint8")]
public class DecimalsFunctionBase : FunctionMessage
{

}

public partial class DecreaseAllowanceFunction : DecreaseAllowanceFunctionBase { }

[Function("decreaseAllowance", "bool")]
public class DecreaseAllowanceFunctionBase : FunctionMessage
{
    [Parameter("address", "spender", 1)]
    public virtual string Spender { get; set; }
    [Parameter("uint256", "subtractedValue", 2)]
    public virtual BigInteger SubtractedValue { get; set; }
}

public partial class DeployerAddressFunction : DeployerAddressFunctionBase { }

[Function("deployerAddress", "address")]
public class DeployerAddressFunctionBase : FunctionMessage
{

}

public partial class GetMsgSenderFunction : GetMsgSenderFunctionBase { }

[Function("getMsgSender", "address")]
public class GetMsgSenderFunctionBase : FunctionMessage
{

}

public partial class GetOwnerFunction : GetOwnerFunctionBase { }

[Function("getOwner", "address")]
public class GetOwnerFunctionBase : FunctionMessage
{

}

public partial class GetPrizeFunction : GetPrizeFunctionBase { }

[Function("getPrize", "bool")]
public class GetPrizeFunctionBase : FunctionMessage
{
    [Parameter("uint256", "amt", 1)]
    public virtual BigInteger Amt { get; set; }
}

public partial class IncreaseAllowanceFunction : IncreaseAllowanceFunctionBase { }

[Function("increaseAllowance", "bool")]
public class IncreaseAllowanceFunctionBase : FunctionMessage
{
    [Parameter("address", "spender", 1)]
    public virtual string Spender { get; set; }
    [Parameter("uint256", "addedValue", 2)]
    public virtual BigInteger AddedValue { get; set; }
}

public partial class NameFunction : NameFunctionBase { }

[Function("name", "string")]
public class NameFunctionBase : FunctionMessage
{

}

public partial class OwnerFunction : OwnerFunctionBase { }

[Function("owner", "address")]
public class OwnerFunctionBase : FunctionMessage
{

}

public partial class SellFunction : SellFunctionBase { }

[Function("sell")]
public class SellFunctionBase : FunctionMessage
{
    [Parameter("uint256", "amount", 1)]
    public virtual BigInteger Amount { get; set; }
}

public partial class SellTokensFunction : SellTokensFunctionBase { }

[Function("sellTokens")]
public class SellTokensFunctionBase : FunctionMessage
{
    [Parameter("uint256", "tokenAmountToSell", 1)]
    public virtual BigInteger TokenAmountToSell { get; set; }
}

public partial class SymbolFunction : SymbolFunctionBase { }

[Function("symbol", "string")]
public class SymbolFunctionBase : FunctionMessage
{

}

public partial class TokensPerEthFunction : TokensPerEthFunctionBase { }

[Function("tokensPerEth", "uint256")]
public class TokensPerEthFunctionBase : FunctionMessage
{

}

public partial class TotalSupplyFunction : TotalSupplyFunctionBase { }

[Function("totalSupply", "uint256")]
public class TotalSupplyFunctionBase : FunctionMessage
{

}

public partial class TransferFunction : TransferFunctionBase { }

[Function("transfer", "bool")]
public class TransferFunctionBase : FunctionMessage
{
    [Parameter("address", "to", 1)]
    public virtual string To { get; set; }
    [Parameter("uint256", "amount", 2)]
    public virtual BigInteger Amount { get; set; }
}

public partial class TransferFromFunction : TransferFromFunctionBase { }

[Function("transferFrom", "bool")]
public class TransferFromFunctionBase : FunctionMessage
{
    [Parameter("address", "from", 1)]
    public virtual string From { get; set; }
    [Parameter("address", "to", 2)]
    public virtual string To { get; set; }
    [Parameter("uint256", "amount", 3)]
    public virtual BigInteger Amount { get; set; }
}

public partial class ApprovalEventDTO : ApprovalEventDTOBase { }

[Event("Approval")]
public class ApprovalEventDTOBase : IEventDTO
{
    [Parameter("address", "owner", 1, true)]
    public virtual string Owner { get; set; }
    [Parameter("address", "spender", 2, true)]
    public virtual string Spender { get; set; }
    [Parameter("uint256", "value", 3, false)]
    public virtual BigInteger Value { get; set; }
}

public partial class BoughtEventDTO : BoughtEventDTOBase { }

[Event("Bought")]
public class BoughtEventDTOBase : IEventDTO
{
    [Parameter("uint256", "amount", 1, false)]
    public virtual BigInteger Amount { get; set; }
}

public partial class BuyTokensEventDTO : BuyTokensEventDTOBase { }

[Event("BuyTokens")]
public class BuyTokensEventDTOBase : IEventDTO
{
    [Parameter("address", "buyer", 1, false)]
    public virtual string Buyer { get; set; }
    [Parameter("uint256", "amountOfETH", 2, false)]
    public virtual BigInteger AmountOfETH { get; set; }
    [Parameter("uint256", "amountOfTokens", 3, false)]
    public virtual BigInteger AmountOfTokens { get; set; }
}

public partial class SoldEventDTO : SoldEventDTOBase { }

[Event("Sold")]
public class SoldEventDTOBase : IEventDTO
{
    [Parameter("uint256", "amount", 1, false)]
    public virtual BigInteger Amount { get; set; }
}

public partial class TransferEventDTO : TransferEventDTOBase { }

[Event("Transfer")]
public class TransferEventDTOBase : IEventDTO
{
    [Parameter("address", "from", 1, true)]
    public virtual string From { get; set; }
    [Parameter("address", "to", 2, true)]
    public virtual string To { get; set; }
    [Parameter("uint256", "value", 3, false)]
    public virtual BigInteger Value { get; set; }
}

public partial class AddressThisOutputDTO : AddressThisOutputDTOBase { }

[FunctionOutput]
public class AddressThisOutputDTOBase : IFunctionOutputDTO
{
    [Parameter("address", "", 1)]
    public virtual string ReturnValue1 { get; set; }
}

public partial class AllowanceOutputDTO : AllowanceOutputDTOBase { }

[FunctionOutput]
public class AllowanceOutputDTOBase : IFunctionOutputDTO
{
    [Parameter("uint256", "", 1)]
    public virtual BigInteger ReturnValue1 { get; set; }
}



public partial class BalanceOfOutputDTO : BalanceOfOutputDTOBase { }

[FunctionOutput]
public class BalanceOfOutputDTOBase : IFunctionOutputDTO
{
    [Parameter("uint256", "", 1)]
    public virtual BigInteger ReturnValue1 { get; set; }
}

public partial class BalanceOfdeployerOutputDTO : BalanceOfdeployerOutputDTOBase { }

[FunctionOutput]
public class BalanceOfdeployerOutputDTOBase : IFunctionOutputDTO
{
    [Parameter("uint256", "", 1)]
    public virtual BigInteger ReturnValue1 { get; set; }
}







public partial class DecimalsOutputDTO : DecimalsOutputDTOBase { }

[FunctionOutput]
public class DecimalsOutputDTOBase : IFunctionOutputDTO
{
    [Parameter("uint8", "", 1)]
    public virtual byte ReturnValue1 { get; set; }
}



public partial class DeployerAddressOutputDTO : DeployerAddressOutputDTOBase { }

[FunctionOutput]
public class DeployerAddressOutputDTOBase : IFunctionOutputDTO
{
    [Parameter("address", "", 1)]
    public virtual string ReturnValue1 { get; set; }
}

public partial class GetMsgSenderOutputDTO : GetMsgSenderOutputDTOBase { }

[FunctionOutput]
public class GetMsgSenderOutputDTOBase : IFunctionOutputDTO
{
    [Parameter("address", "", 1)]
    public virtual string ReturnValue1 { get; set; }
}

public partial class GetOwnerOutputDTO : GetOwnerOutputDTOBase { }

[FunctionOutput]
public class GetOwnerOutputDTOBase : IFunctionOutputDTO
{
    [Parameter("address", "", 1)]
    public virtual string ReturnValue1 { get; set; }
}





public partial class NameOutputDTO : NameOutputDTOBase { }

[FunctionOutput]
public class NameOutputDTOBase : IFunctionOutputDTO
{
    [Parameter("string", "", 1)]
    public virtual string ReturnValue1 { get; set; }
}

public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

[FunctionOutput]
public class OwnerOutputDTOBase : IFunctionOutputDTO
{
    [Parameter("address", "", 1)]
    public virtual string ReturnValue1 { get; set; }
}





public partial class SymbolOutputDTO : SymbolOutputDTOBase { }

[FunctionOutput]
public class SymbolOutputDTOBase : IFunctionOutputDTO
{
    [Parameter("string", "", 1)]
    public virtual string ReturnValue1 { get; set; }
}

public partial class TokensPerEthOutputDTO : TokensPerEthOutputDTOBase { }

[FunctionOutput]
public class TokensPerEthOutputDTOBase : IFunctionOutputDTO
{
    [Parameter("uint256", "", 1)]
    public virtual BigInteger ReturnValue1 { get; set; }
}

public partial class TotalSupplyOutputDTO : TotalSupplyOutputDTOBase { }

[FunctionOutput]
public class TotalSupplyOutputDTOBase : IFunctionOutputDTO
{
    [Parameter("uint256", "", 1)]
    public virtual BigInteger ReturnValue1 { get; set; }
}

