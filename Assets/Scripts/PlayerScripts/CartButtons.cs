using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartButtons : MonoBehaviour
{
    public void addToCartBtn()
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

    public void checkoutDone()
    {
        CartContents.clearCart();
        PlayerLookAt.changeAddToCartBtn();
    }
}
