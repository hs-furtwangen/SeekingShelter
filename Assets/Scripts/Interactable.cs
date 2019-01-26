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

    public void Interact()
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
    }


}
