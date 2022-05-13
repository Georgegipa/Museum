using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentTrigger : MonoBehaviour
{
    //Warning spaghetti! You have been warned!
    [SerializeField] Canvas _canvas; //the canvas that will be used to display info and the cart
    private GameObject infoPanel;
    [SerializeField] bool lookCursor = true;

    //Place the info of the exhibit in the info panel
    void CanvasToPanel(string exhibit_tag = "Agent")
    {
        infoPanel.SetActive(true);
    }

    //Retrieve the individual objects from info panel
    void InfoPanelObjects()
    {
        infoPanel = _canvas.GetComponent<Transform>().gameObject;
    }

    void Start()
    {
        InfoPanelObjects();
        infoPanel.SetActive(false);
    }

    //What happens when the player enter a exhibit's collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != null)
        {
            CanvasToPanel(other.tag);
            lookCursor = false;
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
