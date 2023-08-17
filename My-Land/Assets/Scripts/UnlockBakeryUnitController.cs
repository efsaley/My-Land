using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UnlockBakeryUnitController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bakeryText;
    [SerializeField] private int maxStoredProductCount;
    [SerializeField] private ProductType productType;
    private int storedProductCount;
    // Start is called before the first frame update
    void Start()
    {
        DisplayProductCount();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DisplayProductCount()
    {
        bakeryText.text = storedProductCount.ToString() + "/" + maxStoredProductCount.ToString();
    }

    public ProductType GetNeededProductType()
    {
        return productType;
    }
    public bool StoreProduct()
    {
        if (maxStoredProductCount == storedProductCount)
        {
            return false;
        }
        storedProductCount ++;
        DisplayProductCount();
        return true;
    }
}
