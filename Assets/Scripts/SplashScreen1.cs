using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen1 : MonoBehaviour
{

    public GameObject SplashScreen;
    public GameObject CreditsScreen;
    public GameObject ControlScreen;

    // Start is called before the first frame update
    void Start()
    {
        SplashScreen.SetActive(true);
        CreditsScreen.SetActive(false);
        ControlScreen.SetActive(false);
    }

    public void StartGame()
    {
        SplashScreen.SetActive(false);
        CreditsScreen.SetActive(false);
        ControlScreen.SetActive(false);
    }

    public void OpenCredits()
    {
        CreditsScreen.SetActive(true);
        ControlScreen.SetActive(false);
    }

    public void GoBackToSplashScreen()
    {
        CreditsScreen.SetActive(false);
        ControlScreen.SetActive(false);
    }

    public void OpenControls()
    {
        CreditsScreen.SetActive(false);
        ControlScreen.SetActive(true);
    }
}
