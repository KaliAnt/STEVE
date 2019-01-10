using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{

    public GameObject Joystick;
    public GameObject RotateJoystick;
    public Button PauseBttn;
    public GameObject panel;
    public GameObject panelOptions;
    public GameObject panelUpgrade;
    public GameObject panelVision;
    public GameObject panelFetchers;
    public GameObject panelSpeed;
    public Color colorPaused;
    public Color colorActive;


    private bool isPaused = false;

    void Start()
    {
        Button btn = PauseBttn.GetComponent<Button>();
        btn.onClick.AddListener(PauseGame);
    }
    public void PauseGame()
    {

        if (isPaused)
        {
            panel.SetActive(false);
            panelUpgrade.SetActive(false);
            panelOptions.SetActive(false);
            panelFetchers.SetActive(false);
            panelSpeed.SetActive(false);
            panelVision.SetActive(false);
            PauseBttn.image.color = colorActive;
            Time.timeScale = 1;
            isPaused = false;

            Joystick.SetActive(true);
            RotateJoystick.SetActive(true);
        }
        else
        {
            panel.SetActive(true);
            PauseBttn.image.color = colorPaused;
            Joystick.SetActive(false);
            RotateJoystick.SetActive(false);

            Time.timeScale = 0;
            isPaused = true;
        }
    }
}
