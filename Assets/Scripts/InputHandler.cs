using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class InputHandler : MonoBehaviour
{
    public GameObject Panel;
    public Text AmountText,TotalAmountText,ExtraAmount; 
    public InputField cardnumberText,cardholderText,cvvText;
    public InputField nameText,surnameText,addressText,zipcodeText,mobileText,phoneText,emailText;
    public Toggle option1, option2;
    public Text panel_name,panel_email,panel_phone,panel_ordercode,panel_ordertime;
    double amount,totalamount; 
    private static string cardnumber,cardholder,cvv;
    private static string name,surname,address,zipcode,mobile,phone,email;
    private static string ordercode,ordertime;
    private static bool toggle1, toggle2;
    private static double shippingextra = 30.00;

    // Start is called before the first frame update
    void Start()
    {
        Panel.SetActive(false);
        float temp = CartContents.getTotalPrice();
        AmountText.GetComponent<Text>().text = temp.ToString("F");
        TotalAmountText.GetComponent<Text>().text = AmountText.text;
   }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void FinishOrder()
    {
        bool OrderOk=true;
        initialiseObjects();
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(zipcode) || string.IsNullOrEmpty(mobile) || string.IsNullOrEmpty(email))
        {
            OrderOk = false;
            Debug.Log("Δεν έχτε συμπληρώσει όλα τα απαιτούμενα πεδία");
        }
        if(string.IsNullOrEmpty(cardnumber) || string.IsNullOrEmpty(cardholder) || string.IsNullOrEmpty(cvv))
        {
            OrderOk = false;
            Debug.Log("Δεν έχτε συμπληρώσει όλα τα απαιτούμενα πεδία");
        }
        if(Panel != null && OrderOk)
        {
            panel_name.GetComponent<Text>().text = name + " " + surname;
            panel_email.GetComponent<Text>().text = email;
            panel_phone.GetComponent<Text>().text = phone;
            int rand_num = UnityEngine.Random.Range(100, 200);
            ordercode = "Παραγγελία #" + rand_num.ToString();
            panel_ordercode.GetComponent<Text>().text = ordercode;
            DateTime now = DateTime.Now;
            panel_ordertime.GetComponent<Text>().text = now.ToString("F");
            Panel.SetActive(true);
        }
    }

    void initialiseObjects ()
    {
        name = nameText.text;
        surname = surnameText.text;
        address = addressText.text;
        zipcode = zipcodeText.text;
        mobile = mobileText.text;
        phone = phoneText.text;
        email = emailText.text;
        cardnumber = cardnumberText.text;
        cardholder = cardholderText.text;
        cvv = cvvText.text;
    }

    public void valueChanged(Toggle t)
    {
        if (t.isOn)
        {
            String amount_str = AmountText.text;
            amount = Double.Parse(amount_str);
            amount = amount + shippingextra;
            TotalAmountText.GetComponent<Text>().text = amount.ToString("F");
            ExtraAmount.GetComponent<Text>().text = shippingextra.ToString("F");
        } 
        else
        {
            double zero = 00.00;
            TotalAmountText.GetComponent<Text>().text = AmountText.text;
            ExtraAmount.GetComponent<Text>().text = zero.ToString("F");
        }
    }
}