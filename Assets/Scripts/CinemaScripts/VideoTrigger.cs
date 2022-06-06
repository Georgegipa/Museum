using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoTrigger : MonoBehaviour
{
    [SerializeField] Canvas _canvas; //the canvas that will be used to display info and the cart
    private GameObject infoPanel;
    public VideoPlayer video;

    //Place the info of the exhibit in the info panel
    void CanvasToPanel(string exhibit_tag = "cinema")
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
            video.Play();
        }
    }

    //What happens when the player leaves a exhibit's collider
    private void OnTriggerExit(Collider other)
    {
        if (other.tag != null)
        {
            infoPanel.SetActive(false);
            video.Pause();
        }
    }

    //placeholder , not needed for this script
    void Update()
    {
    }
}
