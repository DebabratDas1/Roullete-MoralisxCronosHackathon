using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        if(Instance!=this && Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private int userChips = 1234;
    public int AvailableChips
    {
        get
        {
            return userChips;
        }
        set
        {

        }
    }


    private int rewardAmt = 0;
    public int RewardAmount
    {
        get
        {
            return rewardAmt;
        }
        set
        {
            rewardAmt = value;
        }
    }


    private int diceOutcome = 0;
    public int DiceOutcome
    {
        get
        {
            return diceOutcome;
        }
        set
        {
            diceOutcome = value;
        }
    }


    private int betAmt;
    public int BetAmt
    {
        get
        {
            return betAmt;
        }
        set
        {
            betAmt = value;
        }
    }

    private int netWin;
    public int NetWin
    {
        get
        {
            return (rewardAmt - betAmt);
        }
    }



    public void ResetGame()
    {
        //Set diceoutcome to 0
        //remove board values
        //
    }

    //public int 
 

}