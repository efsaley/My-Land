using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    private int coins;
    private string keyCoins = "keyCoins";


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }
    public void ExchangeProduct(ProductData productData)
    {
        AddCoin(productData.productPrice); 
    }
    public void AddCoin(int price)
    {
        coins += price;
        DisplayCoins();

    }

    public void SpendCoin(int price)
    {
        coins -= price;
        DisplayCoins();
    }

    public bool TryBuyThisUnit(int price)
    {
        if (GetCoins() >= price)
        {
            SpendCoin(price);
            return true;

        }
        return false;
    }
    // Start is called before the first frame update
    void Start()
    {
        LoadCoins();
        DisplayCoins();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GetCoins()
    {
        return coins;
    }

    private void DisplayCoins()
    {
        UIManager.instance.ShowCoinCountOnScreen(coins);
        SaveCoins();

    }
    private void LoadCoins()
    {
        coins = PlayerPrefs.GetInt (keyCoins, 0);

    }
    private void SaveCoins()
    {
        PlayerPrefs.SetInt(keyCoins, coins);
    }
}
