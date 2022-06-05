using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToOtherView : MonoBehaviour
{
    public static void ToInfoPanel()
    {
        //enable the info panel and disable the other panels
        PlayerLookAt.infoPanel.SetActive(true);
        PlayerLookAt.cartPanel.SetActive(false);
        PlayerLookAt.paymentPanel.SetActive(false);
        PlayerController.move = true;
    }

    public static void ToCheckOut()
    {
        if (CartContents.getNumItems() == 0) //no items in cart means no payment
        {
        }
        else
        {
            //enable the payment panel and disable the other panels
            PlayerLookAt.infoPanel.SetActive(false);
            PlayerLookAt.cartPanel.SetActive(false);
            PlayerLookAt.paymentPanel.SetActive(true);
            PlayerController.move = false;
        }
    }

    public static void ToCart()
    {
        //enable the cart panel and disable the other panels
        PlayerLookAt.infoPanel.SetActive(false);
        PlayerLookAt.cartPanel.SetActive(true);
        PlayerLookAt.paymentPanel.SetActive(false);
        PlayerController.move = false;
    }
}