using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeFetchers : MonoBehaviour
{

    public Text info_text;
    public Button fetcherBttn;

    public GameObject shopObject;

    private ShopController shop;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = fetcherBttn.GetComponent<Button>();
        btn.onClick.AddListener(UpgradeFetcher);

        shop = shopObject.GetComponent<ShopController>();
    }

    // Update is called once per frame
    void UpgradeFetcher()
    {
        if (shop.BuyFetchers(1))
        {
            info_text.text = "Upgraded Fetchers!";
        }
        else
            info_text.text = "Insufficient Funds!";
    }
}
