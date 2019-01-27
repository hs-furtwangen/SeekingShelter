using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class GameController : MonoBehaviour
{
    // Poor mans singelton
    public static GameController Instance;

    //Really importatnt states
    public Dictionary<string, bool> GameStates;

    //all the things to get for methodes
    private Transform Player;
    private Image BlackfadeImage;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        Player = GameObject.FindGameObjectWithTag("Player").transform;
        BlackfadeImage = GameObject.Find("Blackfade").GetComponent<Image>();

        GameStates = new Dictionary<string, bool>
        {
            { "CanMove", true },
            { "Blub", false },
            {"hasFirstQuestItem", false },
            {"hasFirstNumber", false },
            {"hasSecondQuestItem", false },
            {"hasSecondNumber", false },
            {"hasThirdQuestItem", false },
            {"hasThirdNumber", false },
            {"hasFourthNumber", false },
            {"hasFinalKey", false },
            {"isHidden", false }
        };

    }

    public void DoTeleport(Vector2 pos, Cinemachine.CinemachineVirtualCamera ActivateCamera, Cinemachine.CinemachineVirtualCamera DeactivateCamera)
    {
        GameStates["CanMove"] = false;

        StartCoroutine(TeleportCo(pos, ActivateCamera, DeactivateCamera));
    }

    IEnumerator TeleportCo(Vector2 pos, Cinemachine.CinemachineVirtualCamera ActivateCamera, Cinemachine.CinemachineVirtualCamera DeactivateCamera)
    {
        StartCoroutine(FadeOut());
        yield return new WaitForSecondsRealtime(2f);
        Player.transform.position = pos;
        ActivateCamera.enabled = true;
        DeactivateCamera.enabled = false;
        GameStates["CanMove"] = true;
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeOut()
    {
        for (float f = 0f; f < 1; f += 0.01f)
        {
            Color c = BlackfadeImage.color;
            c.a = f;
            BlackfadeImage.color = c;
            yield return null;
        }
    }
    IEnumerator FadeIn()
    {
        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            Color c = BlackfadeImage.color;
            c.a = f;
            BlackfadeImage.color = c;
            yield return null;
        }
    }

}
