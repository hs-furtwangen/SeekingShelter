using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VorhangScript : MonoBehaviour
{
    public bool playerInside;
    public bool isHiddenNow;
    public GameObject closedVorhang;
    public GameObject normalVorhang;

    // Start is called before the first frame update
    void Start()
    {
        playerInside = false;
        isHiddenNow = false;
        normalVorhang.SetActive(true);
        closedVorhang.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")  && playerInside == true)
        {

            if (isHiddenNow == false)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().enabled = false;
                GameController.Instance.GameStates["CanMove"] = false;
                GameController.Instance.GameStates["isHidden"] = true;
                closedVorhang.SetActive(true);
                normalVorhang.SetActive(false);
                isHiddenNow = true;
            } else
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().enabled = true;
                GameController.Instance.GameStates["CanMove"] = true;
                GameController.Instance.GameStates["isHidden"] = false;
                closedVorhang.SetActive(false);
                normalVorhang.SetActive(true);
                isHiddenNow = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
                playerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInside = false;
        }
    }
}
