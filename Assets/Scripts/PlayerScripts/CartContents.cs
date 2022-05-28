using System;
using System.Collections.Generic;
using UnityEngine;

//This script is used to control the contents of the cart
//It contains the list of items in the cart, as well as helper functions to help with cart actions
public class CartContents : MonoBehaviour
{
    private static Dictionary<string,PlayerLookAt.Exhibit> cartItems= new Dictionary<string, PlayerLookAt.Exhibit>();
    //add an item to the cart
    public static void addItem(string tag,PlayerLookAt.Exhibit item)
    {
        if (!cartItems.ContainsKey(tag))
        {
            cartItems.Add(tag, item);
        }
    }
    //remove an item from the dictionary
    public static void removeItem(string tag)
    {
        if (cartItems.ContainsKey(tag))
        {
            cartItems.Remove(tag);
        }
    }
    //get the total price of the cart dictionary
    public static float getTotalPrice()
    {
        float totalPrice = 0;
        foreach (KeyValuePair<string, PlayerLookAt.Exhibit> item in cartItems)
        {
            totalPrice += item.Value.price;
        }
        return totalPrice;
    }
    
    //get the number of items in the cart
    public static int getNumItems()
    {
        return cartItems.Count;
    }

    //get the list of items in the cart
    public static Dictionary<string,PlayerLookAt.Exhibit> getCartContentsDict()
    {
        return cartItems;
    }

    //clear the cart
    public static void clearCart()
    {
        cartItems.Clear();
    }

    public static bool itemExists(string tag)
    {
        return cartItems.ContainsKey(tag);
    }

}
