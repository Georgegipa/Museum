using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShoppingCartBtn : MonoBehaviour
{
    public GameObject panel;
    public GameObject scrollView;
    void clearScrollView()
    {
        foreach (Transform child in scrollView.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
    
    public void AddItemsToScrollView()
    {
        clearScrollView();
        foreach (KeyValuePair<string, PlayerLookAt.Exhibit> item in CartContents.getCartContentsDict())
        {
            //add items to scroll view
            GameObject newPanel = Instantiate(panel);
            var prevImg = newPanel.GetComponent<Transform>().GetChild(0).gameObject;
            var upperText = newPanel.GetComponent<Transform>().GetChild(1).gameObject;
            var lowerText = newPanel.GetComponent<Transform>().GetChild(2).gameObject;
            var btn = newPanel.GetComponent<Transform>().GetChild(3).gameObject;
            prevImg.GetComponent<Image>().sprite = Resources.Load<Sprite>(item.Value.path);
            upperText.GetComponent<Text>().text = item.Value.title;
            lowerText.GetComponent<Text>().text = item.Value.price.ToString() + "\u20AC";
            //instantiate button
            newPanel.transform.SetParent(scrollView.transform);
        }
    }
}
