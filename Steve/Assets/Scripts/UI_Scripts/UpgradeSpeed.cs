using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSpeed : MonoBehaviour
{
    public Text info_text;
    public Button speedButton;

    public GameObject shopObject;

    private ShopController shop;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = speedButton.GetComponent<Button>();
        btn.onClick.AddListener(UpgradePlayerSpeed);

        shop = shopObject.GetComponent<ShopController>();
    }

    // Update is called once per frame
    void UpgradePlayerSpeed()
    {
        if (shop.BuySpeed(1))
        {
            info_text.text = "Upgraded Speed!";
        }
        else
            info_text.text = "Insufficient Funds!";
    }
}