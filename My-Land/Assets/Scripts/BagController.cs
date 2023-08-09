using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagController : MonoBehaviour
{
    [SerializeField] private Transform bag;
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
        if  (other.CompareTag("Respawn"))
        {
            AddProductToBag(other.gameObject);
            Debug.Log("carpisma");
        }

    }
 
    public void AddProductToBag(GameObject product)
    {
        GameObject boxProduct = Instantiate(product, Vector3.zero, Quaternion.identity);
        boxProduct.transform.SetParent(bag, true);

        boxProduct.transform.localRotation = Quaternion.identity;
        boxProduct.transform.localPosition = Vector3.zero;
    }
}
