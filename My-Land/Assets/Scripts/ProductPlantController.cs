using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductPlantController : MonoBehaviour
{
    private bool isReadyToPick;
    private Vector3 originalScale;
    [SerializeField] private ProductData productData;
    private BagController bagController;
    // Start is called before the first frame update
    void Start()
    {
        isReadyToPick = true;
        originalScale = transform.localScale;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isReadyToPick)
        {
            bagController = other.GetComponent<BagController>();
            if (bagController.IsEmptySpace())
            {
                bagController.AddProductToBag(productData);
            isReadyToPick = false; 
            Debug.Log("Touch");
            StartCoroutine(ProductPicked());
            }
            
        }
    }
    IEnumerator ProductPicked()
    {
        float duration = 1f;
        float timer = 0;
        Vector3 targetScale = originalScale / 3;

        while (timer < duration)
        {
            float t = timer / duration;
            Vector3 newScale = Vector3.Lerp(originalScale, targetScale, t);
            transform.localScale = newScale;
            timer += Time.deltaTime;
            yield return null;
        }
        //fide kuculdu
        yield return new WaitForSeconds(8f);

        timer = 0f;
        float growBackDuration = 1f;

        while (timer < growBackDuration)
        {
            float t = timer/ growBackDuration;

            Vector3 newScale = Vector3.Lerp(targetScale, originalScale, t);
            transform.localScale = newScale;
            timer += Time.deltaTime;
            yield return null;


        }
        isReadyToPick = true;
        yield return null;
    
    }
}
