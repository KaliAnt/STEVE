using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectEyeToUpgrade : MonoBehaviour
{
    public Button eyeBttn;
    public Color colorActive;
    public Color colorDisabled;
    public bool disabled = false;
    public GameObject eye;
    public uint eyeNumber;

    public Text info_text;

    private bool isActive = false;
    public GameObject shopObject;

    private ShopController shop;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = eyeBttn.GetComponent<Button>();
        btn.onClick.AddListener(SelectedEye);

        shop = shopObject.GetComponent<ShopController>();

        info_text.text = "Click on the eye you would like to upgrade";
        if (shop && shop.IsActiveEye(eyeNumber))
        {
            disabled = true;
            eyeBttn.image.color = colorActive;
        }
    }

    void SelectedEye()
    {
       
        if (!isActive && shop)
        {
            if (shop.BuyEye(eyeNumber))
            {
                eye.SetActive(true);
                eyeBttn.image.color = colorActive;
                isActive = true;
                info_text.text = "Upgraded Vison!";
            }
            else info_text.text = "Insuficient Funds!";
        }
    }
}
