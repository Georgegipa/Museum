using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLookAt : MonoBehaviour
{
    //Warning spaghetti! Special equipment required. 
    //You have been warned
    [SerializeField] Canvas _canvas;
    [SerializeField] TextAsset jsonFile;
    private GameObject infoPanel, infoPicture, infoText;

    public class Exhibit
    {
        public string path;
        public string info;
        public int qunatity;
        public float price;
    }

    [System.Serializable]
    public class Exhibits
    {
        public Exhibit[] exhibit;
    }

    void Start()
    {
        //Get the first gameobject(This gets the info panel)
        var infoPanel = _canvas.GetComponent<Transform>().GetChild(0).gameObject;
        var infopanelobjects = infoPanel.GetComponent<Transform>();
        var infoPicture = infopanelobjects.GetChild(0).gameObject;
        infoText = infopanelobjects.GetChild(1).gameObject;
        infoText.GetComponent<Text>().text = "Hello World";
        Debug.Log("Hello there");

        //get things from json
        Exhibits list = new Exhibits();
        list = JsonUtility.FromJson<Exhibits>(jsonFile.text);
        foreach (var ex in list.exhibit)
        {
            Debug.Log(ex.path + ex.info + ex.qunatity + ex.price);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}