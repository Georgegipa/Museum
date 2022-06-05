using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpScript : MonoBehaviour
{
    public GameObject panel;
    public GameObject showInfoText;
    public GameObject paymentPanel;
    private GameObject panel1;
    private GameObject panel2;
    private GameObject panel3;
    private GameObject pages;
    private GameObject Next;


    void Start()
    {
        panel.SetActive(false);
        panel1 = panel.GetComponent<Transform>().GetChild(1).gameObject;
        panel2 = panel.GetComponent<Transform>().GetChild(2).gameObject;
        panel3 = panel.GetComponent<Transform>().GetChild(3).gameObject;
        pages = panel.GetComponent<Transform>().GetChild(4).gameObject;
        Next = panel.GetComponent<Transform>().GetChild(5).gameObject;
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);
    }
    
    void Update()
    {
        if (!paymentPanel.activeSelf)
        {
            if(Input.GetKeyDown("i"))
            {
                if(panel.activeSelf)
                {
                    panel.SetActive(false);
                    panel1.SetActive(false);
                    panel2.SetActive(false);
                    panel3.SetActive(false);
                    showInfoText.GetComponent<Text>().text = "Για την λήψη βοήθειας πατήστε 'i'";
                }
                else
                {
                    panel.SetActive(true);
                    panel1.SetActive(true);
                    pages.GetComponent<Text>().text = "Σελίδα 1/3";
                    Next.SetActive(true);
                    showInfoText.GetComponent<Text>().text = "Για έξοδο από τον οδηγό πατήστε 'i'";
                }
            }
            if(Input.GetKeyDown("e"))
            {
                if(panel1.activeSelf)
                {
                    panel2.SetActive(true);
                    panel1.SetActive(false);
                    pages.GetComponent<Text>().text = "Σελίδα 2/3";
                }
                else
                {
                    panel3.SetActive(true);
                    panel2.SetActive(false);
                    pages.GetComponent<Text>().text = "Σελίδα 3/3";
                    Next.SetActive(false);
                }
            }
        }
    }
}