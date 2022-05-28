using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddToCart : MonoBehaviour
{
    //add the selected item to the cart
    public void buttonAction()
    {
        var e = PlayerLookAt.currentExhibit;
        if(e == null)//player is not looking at an exhibit
            return;
        
        if (CartContents.itemExists(e.Item1))
        {
            CartContents.removeItem(e.Item1);
        }
        else
            CartContents.addItem(e.Item1,e.Item2);
        Debug.Log("Items in cart: " + CartContents.getNumItems());
        PlayerLookAt.changeAddToCartBtn();
    }
}
