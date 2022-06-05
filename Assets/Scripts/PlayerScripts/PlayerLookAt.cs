using System;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class PlayerLookAt : MonoBehaviour
{
    //Warning spaghetti! You have been warned!
    public static Tuple<string,Exhibit> currentExhibit;//Tuple is a pair of objects , string is the tag of the object and Exhibit is the object itself
    [SerializeField] Canvas _canvas; //the canvas that will be used to display info and the cart
    [SerializeField] TextAsset jsonFile;//the json file that will be used to retrieve the data for every exhibit
    private static GameObject  moreinfoPanel,infoPicture, infoText, infoTitle,addToCartbtn,addToCartIcon,topCornerCartIcon,topCornerCartPriceText; //the info panel components
    private Dictionary<string, Exhibit> exhibitDictionary;
    public static GameObject infoPanel, cartPanel,paymentPanel;
    public static bool insideExbibitCollider= false;//check if the player is looking at a exhibit

    //The following objects are used to store the information from the json file
    [Serializable]
    public class Exhibit
    {
        public string title;
        public string path;
        public string info;
        public int quantity;
        public float price;
    }

    //This can be done better using unity's built in json parser but I can't get it to work
    void JSONToDictionary()
    {
        //deserialize the json file
        DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(jsonFile.text);
        DataTable dataTable = dataSet.Tables["exhibits"];
        //create a dictionary to store the data
        exhibitDictionary = new Dictionary<string, Exhibit>();
        //loop through the data and add it to the dictionary
        foreach (DataRow row in dataTable.Rows)
        {
            Exhibit exhibit = new Exhibit();
            exhibit.title = row["title"].ToString();
            exhibit.path = row["path"].ToString();
            exhibit.info = row["info"].ToString();
            exhibit.quantity = int.Parse(row["quantity"].ToString());
            exhibit.price = float.Parse(row["price"].ToString());
            exhibitDictionary.Add(row["tag"].ToString(), exhibit);
        }
    }

    //Place the info of the exhibit in the info panel
    void JSONtoInfoPanel(string exhibit_tag = "Exhibit 1")
    {
        if (exhibitDictionary.ContainsKey(exhibit_tag))
        {
            insideExbibitCollider = true;
            moreinfoPanel.SetActive(true);
            infoText.GetComponent<Text>().text = exhibitDictionary[exhibit_tag].info;
            infoTitle.GetComponent<Text>().text = exhibitDictionary[exhibit_tag].title;
            infoPicture.GetComponent<Image>().sprite = Resources.Load<Sprite>(exhibitDictionary[exhibit_tag].path);
            currentExhibit = new Tuple<string, Exhibit>(exhibit_tag, exhibitDictionary[exhibit_tag]);//set the current exhibit to the one that is currently being looked at
            changeAddToCartBtn();
        }
    }

    //Retrieve the individual objects from info panel
    void InfoPanelObjects()
    {
        var parentpanel = _canvas.transform.Find("InfoPanel");
        infoPanel = parentpanel.gameObject;
        moreinfoPanel = parentpanel.GetComponent<Transform>().GetChild(0).gameObject;
        cartPanel = _canvas.transform.Find("CartPanel").gameObject;
        cartPanel.SetActive(false);
        paymentPanel = _canvas.transform.Find("PaymentPanel").gameObject;
        paymentPanel.SetActive(false);
        topCornerCartIcon = parentpanel.GetComponent<Transform>().GetChild(1).gameObject;
        topCornerCartPriceText = topCornerCartIcon.GetComponent<Transform>().GetChild(0).gameObject;
        var infopanelobjects = moreinfoPanel.GetComponent<Transform>();
        infoTitle = infopanelobjects.GetChild(0).gameObject;
        infoPicture = infopanelobjects.GetChild(1).gameObject;
        infoText = infopanelobjects.GetChild(2).gameObject;
        var addtocart = infopanelobjects.GetChild(3).gameObject;
        addToCartIcon = addtocart.transform.GetChild(0).gameObject;
        addToCartbtn = addtocart.transform.GetChild(1).gameObject;
    }

    void Start()
    {
        InfoPanelObjects();
        moreinfoPanel.SetActive(false);
        JSONToDictionary();
        currentExhibit = null;
    }

    //What happens when the player enter a exhibit's collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != null)
        {
            JSONtoInfoPanel(other.tag);
        }
    }

    //What happens when the player leaves a exhibit's collider
    private void OnTriggerExit(Collider other)
    {
        if (other.tag != null)
        {
            insideExbibitCollider =false;
            moreinfoPanel.SetActive(false);
            currentExhibit = null;
        }
    }

    public static void changeAddToCartBtn()
    {
        //check if the exhibit is already in the cart
        if (CartContents.getNumItems()>0)
        {
            topCornerCartIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/items_in_cart");
            topCornerCartPriceText.GetComponent<Text>().text = CartContents.getTotalPrice().ToString() + "€";
        }
        else 
        {
            topCornerCartPriceText.GetComponent<Text>().text = "";
            topCornerCartIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/empty_cart");
        }
        if(insideExbibitCollider)
        {//update the add to cart button in the infopanel only if the player is looking at an exhibit
            if (CartContents.itemExists(currentExhibit.Item1))
            {
                //set addCartBtn text
                addToCartbtn.GetComponentInChildren<Text>().text = "ΑΦΑΙΡΕΣΗ ΑΠΟ ΤΟ ΚΑΛΑΘΙ";
                //change the icon
                addToCartIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/remove_from_cart");
            }
            else
            {
                addToCartbtn.GetComponentInChildren<Text>().text = "ΠΡΟΣΘΗΚΗ ΣΤΟ ΚΑΛΑΘΙ";
                addToCartIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/add_to_cart");
            }
        }
    }
    
    
    
    //placeholder , not needed for this script
    void Update()
    {
        
    }
}