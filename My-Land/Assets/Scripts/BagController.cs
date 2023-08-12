using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagController : MonoBehaviour
{
    public List<ProductData> productDataList;
    [SerializeField] private Transform bag;
    private Vector3 productSize;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
 
    public void AddProductToBag(ProductData productData)
    {
        GameObject boxProduct = Instantiate(productData.productPrefab, Vector3.zero, Quaternion.identity);
        boxProduct.transform.SetParent(bag, true);
        CalculateObjectSize(boxProduct);
        float yPosition = CalculateNewYPositionOfBox();

        boxProduct.transform.localRotation = Quaternion.identity;
        boxProduct.transform.localPosition = Vector3.zero;
        boxProduct.transform.localPosition = new Vector3(0, yPosition, 0);
        productDataList.Add(productData);
    }

    private float CalculateNewYPositionOfBox()
    {
        float newYPos = productSize.y * productDataList.Count;
        return newYPos;

    }

    private void CalculateObjectSize(GameObject gameObject)
    {
        if (productSize == Vector3.zero)
        {
            MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>();
            productSize = renderer.bounds.size;
        }

    }
}
