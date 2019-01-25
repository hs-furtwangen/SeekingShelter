using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Poor mans singelton
    public static GameController Instance;

    //Really importatnt states
    public bool CanMove = true;

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

    }

    public void DoTeleport(Vector2 pos)
    {
        CanMove = false;

        StartCoroutine(TeleportCo(pos));
    }

    IEnumerator TeleportCo(Vector2 pos)
    {
        StartCoroutine(FadeOut());
        yield return new WaitForSecondsRealtime(5f);
        Player.Translate(pos);
        CanMove = true;
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
