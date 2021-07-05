using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DailyRewardSystem : MonoBehaviour
{
    [SerializeField] bool readyToClaim;
    [SerializeField] Button clickButton;

    [SerializeField] Text coinTxt;
    [SerializeField] int Coin;

    [SerializeField] Text countDownText;
    [SerializeField] bool timeStart;
    [SerializeField] float timeRemaining;
    [SerializeField] float hours;
    [SerializeField] float minutes;
    [SerializeField] float seconds;

    //To delete saves
    [SerializeField] bool deleteAllFiles;

    //int for timeStart bool
    [SerializeField] int TS;
    //int for readyToClaim bool
    [SerializeField] int RC;

    void Start()
    {
        Coin = PlayerPrefs.GetInt("Coins");
        CountDownSystem();

        BoolStates();
    }

    void Update()
    {
        DeleteSaves();
        BoolStates();

        countDownText.text = "Time: " + hours + "h " + minutes + "m " + seconds + "s ";
        CountDownSystem();

        Coin = PlayerPrefs.GetInt("Coins");
        coinTxt.text = "Coin: " + Coin.ToString();

        if(!readyToClaim)
        {
            clickButton.interactable = false;
        }
        if(readyToClaim)
        {
            clickButton.interactable = true;
        }

        if (timeStart)
        {
            timeRemaining -= Time.deltaTime;

            if(timeRemaining <= 0)
            {
                clickButton.interactable = true;

                PlayerPrefs.SetInt("timeStartBOOL", 0);
                PlayerPrefs.SetInt("readyToClaimBOOL", 0);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void GetCoins(int amount)
    {
        PlayerPrefs.SetInt("timeStartBOOL", 1);
        PlayerPrefs.SetInt("readyToClaimBOOL", 1);

        Coin += amount;
        PlayerPrefs.SetInt("Coins", Coin);

        clickButton.interactable = false;
    }

    void CountDownSystem()
    {
        hours = Mathf.FloorToInt(timeRemaining / 3600);
        minutes = Mathf.FloorToInt(timeRemaining / 60 % 60);
        seconds = Mathf.FloorToInt(timeRemaining % 60);
    }

    void DeleteSaves()
    {
        if (deleteAllFiles)
        {
            PlayerPrefs.DeleteAll();
            clickButton.interactable = true;
            timeStart = false;
            readyToClaim = true;

            Debug.Log("Saves are deleted");
        }
        else
        {

        }
    }

    void BoolStates()
    {
        TS = PlayerPrefs.GetInt("timeStartBOOL");
        RC = PlayerPrefs.GetInt("readyToClaimBOOL");

        if(TS == 1)
        {
            timeStart = true;
        }
        else if(TS == 0)
        {
            timeStart = false;
        }

        if (RC == 1)
        {
            readyToClaim = false;
        }
        else if (RC == 0)
        {
            readyToClaim = true;
            clickButton.interactable = true;
        }
    }
}
