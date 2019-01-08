using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenPanel : MonoBehaviour
{
    public Button openButton;
    public GameObject targetPanel;
    public GameObject currentPanel;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = openButton.GetComponent<Button>();
        btn.onClick.AddListener(DisplayPanel);
    }

    void DisplayPanel()
    {
        targetPanel.SetActive(true);
        currentPanel.SetActive(false);
    }

}
