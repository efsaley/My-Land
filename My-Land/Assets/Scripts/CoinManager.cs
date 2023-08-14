using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    private int coins;


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

    }
}
