using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectEyeToUpgrade : MonoBehaviour
{
    public Button eyeBttn;
    public Color colorActive;
    public Color colorDisabled;

    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = eyeBttn.GetComponent<Button>();
        btn.onClick.AddListener(SelectedEye);
    }

    void SelectedEye()
    {
        if (isActive)
        {
            eyeBttn.image.color = colorDisabled;
            isActive = false;
        }
        else
        {
            eyeBttn.image.color = colorActive;
            isActive = true;
        }
    }
}
