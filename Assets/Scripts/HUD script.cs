using UnityEngine;
using UnityEngine.UI;

public class HUDscript : MonoBehaviour
{
    [SerializeField] Text UItext;
    [SerializeField] Canvas _canvas;

    // Start is called before the first frame update
    void Start()
    {
        _canvas.SendMessage("Hello Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
