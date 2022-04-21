using System;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class PlayerLookAt : MonoBehaviour
{
    //Warning spaghetti! You have been warned!
    [SerializeField] Canvas _canvas; //the canvas that will be used to display info and the cart
    [SerializeField] TextAsset jsonFile;//the json file that will be used to retrieve the data for every exhibit
    private GameObject infoPanel, infoPicture, infoText, infoTitle; //the info panel components
    private Dictionary<string, Exhibit> exhibitDictionary;

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

        //now display the data
        foreach (KeyValuePair<string, Exhibit> entry in exhibitDictionary)
        {
            Debug.Log(entry.Key + " - " + entry.Value.info);
        }
    }

    //Place the info of the exhibit in the info panel
    void JSONtoInfoPanel(string exhibit_tag = "Exhibit 1")
    {
        if (exhibitDictionary.ContainsKey(exhibit_tag))
        {
            infoPanel.SetActive(true);
            infoText.GetComponent<Text>().text = exhibitDictionary[exhibit_tag].info;
            infoTitle.GetComponent<Text>().text = exhibitDictionary[exhibit_tag].title;
            infoPicture.GetComponent<Image>().sprite = Resources.Load<Sprite>(exhibitDictionary[exhibit_tag].path);
        }
    }

    //Retrieve the individual objects from info panel
    void InfoPanelObjects()
    {
        infoPanel = _canvas.GetComponent<Transform>().GetChild(0).gameObject;
        var infopanelobjects = infoPanel.GetComponent<Transform>();
        infoTitle = infopanelobjects.GetChild(0).gameObject;
        infoPicture = infopanelobjects.GetChild(1).gameObject;
        infoText = infopanelobjects.GetChild(2).gameObject;
    }

    void Start()
    {
        InfoPanelObjects();
        infoPanel.SetActive(false);
        JSONToDictionary();
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
            infoPanel.SetActive(false);
        }
    }

    //placeholder , not needed for this script
    void Update()
    {
    }
}