using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToScrollVIew : MonoBehaviour
{
    //add a panel to the scroll view
    public GameObject panel;
    public GameObject scrollView;
    
    //function to add a panel to the scroll view
    //cmno work you stupid
       public void AddPanel()
    {
        GameObject newPanel = Instantiate(panel);
        newPanel.transform.SetParent(scrollView.transform);
    }


}
