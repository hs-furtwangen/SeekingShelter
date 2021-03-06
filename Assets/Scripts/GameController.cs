﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Poor mans singelton
    public static GameController Instance;

    //Really importatnt states
    public Dictionary<string, bool> GameStates;

    public GameObject CurrentRoom;

    //all the things to get for methodes
    private Transform Player;
    private Image BlackfadeImage;

    public float GhostTime = 15f;
    private float GhostTimer = 0;

    public GameObject GhostPrefab;
    private GameObject ActiveGhost;

    public Cinemachine.CinemachineVirtualCamera ActiveCam;
    public Cinemachine.CinemachineVirtualCamera KillCam;

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
            {"isHidden", false },
            {"canSpawnGhost", false },
            {"aboutToSpawnGhost", false },
            {"ghostHasSpawned", false },
        };

    }

    void Update()
    {
        if (GameStates["hasFirstNumber"] && GameStates["hasSecondNumber"] && GameStates ["hasThirdNumber"] && !GameStates["hasFourthNumber"])
        {
            GameStates["hasFourthNumber"] = true;
        }


        if (GameStates["canSpawnGhost"])
        {
            if (GameStates["aboutToSpawnGhost"])
            {
                if (GhostTimer > 0)
                {
                    if (!GameStates["isHidden"])
                    {
                        GhostTimer -= Time.deltaTime;
                    }
                }
                else
                {
                    SpawnGhost();
                }

            }
            else
            {
                if (GhostTimer > 0)
                {
                    GhostTimer -= Time.deltaTime;
                }
                else
                {
                    GameStates["aboutToSpawnGhost"] = true;
                    GhostTimer = GhostTime;
                    SoundManager.Instance.BackgroundChange(2);
                }
            }
        }

        if (GameStates["ghostHasSpawned"] && GameStates["isHidden"])
        {
            FuckOffGhost();
        }
    }

    public void FuckOffGhost()
    {
        ActiveGhost.GetComponent<Animator>().enabled = false;
        StartCoroutine(FadeOut(ActiveGhost.GetComponent<SpriteRenderer>(), true));
        GameStates["ghostHasSpawned"] = false;
        GameStates["canSpawnGhost"] = true;
        GameStates["ghostIsAboutToSpawn"] = false;

        GhostTimer = GhostTime * 2;
    }

    public void SpawnGhost(bool overridecanspawnghost = false)
    {
        if ((GameStates["canSpawnGhost"] || overridecanspawnghost) && CurrentRoom != null)
        {
            SoundManager.Instance.BackgroundChange(3);
            GameStates["canSpawnGhost"] = false;
            GameStates["ghostHasSpawned"] = true;
            Debug.Log("Spawning");

            var go = Instantiate(GhostPrefab);
            go.transform.parent = CurrentRoom.transform;
            go.transform.localPosition = Vector3.zero;

            Destroy(go, 10f);

            var anim = go.GetComponent<Animator>();

            if (Random.Range(0, 1) > 0.5f)
            {
                go.transform.localPosition = Vector3.left * 3.2f;
                Debug.Log("LEFT");
                anim.SetBool("LeftSpawn", false);
                anim.SetBool("HeAtac", true);
            }
            else
            {
                go.transform.localPosition = Vector3.right * 3.2f;
                Debug.Log("RIGHT");
                anim.SetBool("LeftSpawn", true);
                anim.SetBool("HeAtac", true);
            }

            ActiveGhost = go;
        }
    }

    public void KillPlayer()
    {
        DoTeleport(new Vector2(34.17102f, -16.89323f), KillCam, ActiveCam, null, false);
        GameStates["ghostHasSpawned"] = false;
        GameStates["canSpawnGhost"] = false;
        GameStates["ghostIsAboutToSpawn"] = false;

    }

    public void DoTeleport(Vector2 pos, Cinemachine.CinemachineVirtualCamera ActivateCamera, Cinemachine.CinemachineVirtualCamera DeactivateCamera, GameObject GoingToRoom, bool canSpawnGhost = true)
    {
        if (ActiveGhost != null)
        {
            var anim = ActiveGhost.GetComponent<Animator>();
            anim.enabled = false;
            Destroy(ActiveGhost, 2f);
        }

        GameStates["CanMove"] = false;

        StartCoroutine(TeleportCo(pos, ActivateCamera, DeactivateCamera));

        ActiveCam = ActivateCamera;

        CurrentRoom = GoingToRoom;

        GameStates["canSpawnGhost"] = canSpawnGhost;
        GameStates["aboutToSpawnGhost"] = false;

        GhostTimer = GhostTime;

        SoundManager.Instance.BackgroundChange(0);
    }

    IEnumerator TeleportCo(Vector2 pos, Cinemachine.CinemachineVirtualCamera ActivateCamera, Cinemachine.CinemachineVirtualCamera DeactivateCamera)
    {
        StartCoroutine(FadeOut(BlackfadeImage));
        yield return new WaitForSecondsRealtime(2f);
        Player.transform.position = pos;
        ActivateCamera.enabled = true;
        DeactivateCamera.enabled = false;
        GameStates["CanMove"] = true;
        StartCoroutine(FadeIn(BlackfadeImage));
    }

    IEnumerator FadeOut(Image sr, bool destroy = false)
    {
        for (float f = 0f; f < 1; f += 0.01f)
        {
            Color c = sr.color;
            c.a = f;
            sr.color = c;
            yield return null;
        }

        if (destroy)
        {
            Destroy(sr.gameObject);
        }
    }
    IEnumerator FadeIn(Image sr)
    {
        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            Color c = sr.color;
            c.a = f;
            sr.color = c;
            yield return null;
        }
    }
    IEnumerator FadeOut(SpriteRenderer sr, bool destroy = false)
    {
        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            Color c = sr.color;
            c.a = f;
            sr.color = c;
            yield return null;
        }

        if (destroy)
        {
            Destroy(sr.gameObject);
            SoundManager.Instance.BackgroundChange(0);
        }
    }
    IEnumerator FadeIn(SpriteRenderer sr)
    {
        for (float f = 0f; f < 1; f += 0.01f)
        {
            Color c = sr.color;
            c.a = f;
            sr.color = c;
            yield return null;
        }
    }

}
