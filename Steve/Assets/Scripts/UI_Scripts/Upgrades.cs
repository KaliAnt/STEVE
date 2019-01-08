using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public Button upgradesBttn;
    public GameObject upgradesPanel;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = upgradesBttn.GetComponent<Button>();
        btn.onClick.AddListener(DisplayShop);
    }

    void DisplayShop()
    {
        upgradesPanel.SetActive(true);


    }
}
