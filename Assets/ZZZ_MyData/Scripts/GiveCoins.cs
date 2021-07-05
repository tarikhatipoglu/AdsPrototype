using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiveCoins : MonoBehaviour
{
    [SerializeField] int Coin;
    [SerializeField] bool deleteSave;
    [SerializeField] Text coinTxt;

    void Start()
    {
        deleteSave = false;
        Coin = PlayerPrefs.GetInt("Coins");
    }

    void Update()
    {
        coinTxt.text = "Coin: " + Coin.ToString();
        Coin = PlayerPrefs.GetInt("Coins");

        if (deleteSave)
        {
            Coin = 0;
            PlayerPrefs.DeleteKey("Coins");
            Debug.Log(PlayerPrefs.GetInt("Coins"));
        }
    }

    public void GetCoins(int amount)
    {
        Coin += amount;
        PlayerPrefs.SetInt("Coins", Coin);
    }
}
