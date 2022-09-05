// SPDX-License-Identifier: MIT
pragma solidity ^0.8.0;
import "hardhat/console.sol";
import "https://github.com/OpenZeppelin/openzeppelin-contracts/blob/master/contracts/token/ERC20/ERC20.sol";

/*interface IERC20 {

    function totalSupply() external view returns (uint256);
    function balanceOf(address account) external view returns (uint256);
    function allowance(address owner, address spender) external view returns (uint256);

    function transfer(address recipient, uint256 amount) external returns (bool);
    function approve(address spender, uint256 amount) external returns (bool);
    function transferFrom(address sender, address recipient, uint256 amount) external returns (bool);


    event Transfer(address indexed from, address indexed to, uint256 value);
    event Approval(address indexed owner, address indexed spender, uint256 value);
}*/


contract BuySell1 is ERC20 {

    //string public constant name = "ERC20Basic";
    //string public constant symbol = "ERC";
    //uint8 public constant decimals = 18;

mapping(address => uint256) balances;

    mapping(address => mapping (address => uint256)) allowed;

    
    address public owner;


   constructor() ERC20('BSE1','BuySell1'){
       owner=msg.sender;
        _mint(msg.sender,100*10**18);
    }


    event Bought(uint256 amount);
    event Sold(uint256 amount);

    function sell(uint256 amount) public {
        require(amount > 0, "You need to sell at least some tokens");
        uint256 allow = allowance(msg.sender, address(this));
        require(allow >= amount, "Check the token allowance");
        transferFrom(msg.sender, address(this), amount);
        payable(msg.sender).transfer(amount);
        emit Sold(amount);
    }


    function buy(uint256 amountTobuy) payable public {
       // uint256 amountTobuy = msg.value;
        uint256 dexBalance = balanceOf(deployerAddress);
        require(amountTobuy > 0, "You need to send some ether");
        require(amountTobuy <= dexBalance, "Not enough tokens in the reserve");
        _transfer(deployerAddress,msg.sender, amountTobuy);
        emit Bought(amountTobuy);
    }



    function addressThis() public view returns (address){
        return (address(this));
    }

    function balanceOfdeployer() public view returns (uint256){
        return (balanceOf(0xB65f5Ac5eAD9598f7Ec61c8C89033B970dA7B77D));
    }

uint256 public tokensPerEth = 100000;
address constant public deployerAddress = 0xB65f5Ac5eAD9598f7Ec61c8C89033B970dA7B77D;
event BuyTokens(address buyer, uint256 amountOfETH, uint256 amountOfTokens);
    
    function buyTokens() public payable returns (uint256 tokenAmount) {
    require(msg.value > 0, "Send ETH to buy some tokens");

    uint256 amountToBuy = msg.value * tokensPerEth;

    // check if the Vendor Contract has enough amount of tokens for the transaction
    uint256 vendorBalance = balanceOf(deployerAddress);
    require(vendorBalance >= amountToBuy, "Vendor contract has not enough tokens in its balance");

    // Transfer token to the msg.sender
    _transfer(deployerAddress, msg.sender, amountToBuy);
    //require(sent, "Failed to transfer token to user");

    // emit the event
    emit BuyTokens(msg.sender, msg.value, amountToBuy);

    return amountToBuy;
  }

 function getOwner() public view returns (address) {
        return owner;
    }

    function getMsgSender() public view returns (address) {
        return msg.sender;
    }




function sellTokens(uint256 tokenAmountToSell) public {
    // Check that the requested amount of tokens to sell is more than 0
    require(tokenAmountToSell > 0, "Specify an amount of token greater than zero");

    // Check that the user's token balance is enough to do the swap
    uint256 userBalance = balanceOf(msg.sender);
    require(userBalance >= tokenAmountToSell, "Your balance is lower than the amount of tokens you want to sell");

    // Check that the Vendor's balance is enough to do the swap
    uint256 amountOfETHToTransfer = tokenAmountToSell / tokensPerEth;
    uint256 ownerETHBalance = owner.balance;
    require(ownerETHBalance >= amountOfETHToTransfer, "Vendor has not enough funds to accept the sell request");

     _transfer(msg.sender, owner, tokenAmountToSell);
    //require(sent, "Failed to transfer tokens from user to vendor");


    bool etherSent;
    (etherSent, )=msg.sender.call{value: amountOfETHToTransfer}("");
    require(etherSent, "Failed to send ETH to the user");
    payable(msg.sender).transfer(1);
  }


  function bid(uint256 amt) public returns (bool){
      bool sent = false;
      _transfer(msg.sender,deployerAddress,amt);
      sent =true;
      return sent;
  }

  function getPrize(uint amt) public returns (bool){
      bool received=false;
      _transfer(deployerAddress,msg.sender,amt);
      received=true;
      return received;
  }

}

