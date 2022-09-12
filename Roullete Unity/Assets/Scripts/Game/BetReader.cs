using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BetReader : MonoBehaviour
{
    [Header("Bet Fields")]
    [SerializeField] private TMP_InputField n1, n2, n3, n4, n5, n6;

    private int bet1, bet2, bet3, bet4, bet5, bet6;
    public int BetFor1
    {
        get
        {
            return int.Parse(n1.text);
        }
    }
    public int BetFor2
    {
        get
        {
            return int.Parse(n2.text);
        }
    }
    public int BetFor3
    {
        get
        {
            return int.Parse(n3.text);
        }
    }
    public int BetFor4
    {
        get
        {
            return int.Parse(n4.text);
        }
    }
    public int BetFor5
    {
        get
        {
            return int.Parse(n5.text);
        }
    }
    public int BetFor6
    {
        get
        {
            return int.Parse(n6.text);
        }
    }

}
