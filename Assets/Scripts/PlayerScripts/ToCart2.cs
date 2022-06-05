using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToCart2 : MonoBehaviour
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
        int i = 0;
        foreach (KeyValuePair<string, PlayerLookAt.Exhibit> item in CartContents.getCartContentsDict())
        {
            //add items to scroll view
            GameObject newPanel = Instantiate(panel);
            var prevImg = newPanel.GetComponent<Transform>().GetChild(0).gameObject;
            var upperText = newPanel.GetComponent<Transform>().GetChild(1).gameObject;
            var lowerText = newPanel.GetComponent<Transform>().GetChild(2).gameObject;
            var btn = newPanel.GetComponent<Transform>().GetChild(3).gameObject;
            btn.name = i.ToString();//set button name to index so we can reference it later
            //change the onclick function to remove the item from the cart
            btn.GetComponent<Button>().onClick.AddListener(() => RemoveItemFromCart(btn.name));
            prevImg.GetComponent<Image>().sprite = Resources.Load<Sprite>(item.Value.path);
            upperText.GetComponent<Text>().text = item.Value.title;
            lowerText.GetComponent<Text>().text = item.Value.price.ToString() + "\u20AC";
            //instantiate button
            newPanel.transform.SetParent(scrollView.transform);
            i++;
        }
    }

    //this function is called when the remove button is pressed
    private void RemoveItemFromCart(string btnName)
    {
        //use the name of the button to find the item that is going to be removed
        int item = int.Parse(btnName);
        //remove the button's parent
        Destroy(scrollView.transform.GetChild(int.Parse(btnName)).gameObject);
        //remove item from cart
        CartContents.removeItem(item);
        PlayerLookAt.changeAddToCartBtn();//update info panel
    }
}
