using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool Teleport;
    public Transform TeleportTransform;
    public Vector3 TeleportLocation;
    public Cinemachine.CinemachineVirtualCamera ActivateCamera;
    public Cinemachine.CinemachineVirtualCamera DeactivateCamera;

    public List<string> GameStatesToEnable;
    public List<string> GameStatesToDisable;
    public List<string> GameStatesToToggle;

    public List<string> DependsOnGameStates;

    public bool Playsound;
    public int SoundID;

    private Material mat;

    private bool active;

    void Start()
    {
        try
        {
            var tempmat = GetComponent<SpriteRenderer>().material;
            if (tempmat.shader.name == "Sprites/Invertable")
            {
                mat = tempmat;
            }
        }
        catch { }
    }

    void Update()
    {
        if (!active)
        {
            if (DependsOnGameStates == null || DependsOnGameStates.Count < 1)
            {
                active = true;
            }
            else
            {
                bool check = true;

                foreach (var state in DependsOnGameStates)
                {
                    if (GameController.Instance.GameStates.ContainsKey(state))
                    {
                        if (!GameController.Instance.GameStates[state])
                        {
                            check = false;
                        }
                    }
                }

                active = check;
            }
        }
    }

    public void Interact()
    {
        if (active)
        {
            if (Teleport)
            {
                if (ActivateCamera != null && DeactivateCamera != null)
                {
                    if (TeleportTransform != null)
                    {
                        GameController.Instance.DoTeleport(TeleportTransform.position, ActivateCamera, DeactivateCamera);
                    }
                    else
                    {
                        GameController.Instance.DoTeleport(TeleportLocation, ActivateCamera, DeactivateCamera);
                    }
                }
            }

            if (GameStatesToEnable != null && GameStatesToEnable.Count > 0)
            {
                foreach (var state in GameStatesToEnable)
                {
                    if (GameController.Instance.GameStates.ContainsKey(state))
                    {
                        GameController.Instance.GameStates[state] = true;
                    }
                }
            }

            if (GameStatesToDisable != null && GameStatesToDisable.Count > 0)
            {
                foreach (var state in GameStatesToDisable)
                {
                    if (GameController.Instance.GameStates.ContainsKey(state))
                    {
                        GameController.Instance.GameStates[state] = false;
                    }
                }
            }

            if (GameStatesToToggle != null && GameStatesToToggle.Count > 0)
            {
                foreach (var state in GameStatesToToggle)
                {
                    if (GameController.Instance.GameStates.ContainsKey(state))
                    {
                        GameController.Instance.GameStates[state] = !GameController.Instance.GameStates[state];
                    }
                }
            }

            if (Playsound)
            {
                SoundManager.Instance.Playsound(SoundID);
            }
        }
    }

    public void HighlightStart()
    {
        if (active)
        {
            if (mat != null)
            {
                mat.SetFloat("_InvertColors", 1);
            }
        }
    }

    public void HighlightStop()
    {
        if (active)
        {
            if (mat != null)
            {
                mat.SetFloat("_InvertColors", 0);
            }
        }
    }
}
