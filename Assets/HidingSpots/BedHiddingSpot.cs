using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedHiddingSpot : MonoBehaviour
{
    public bool playerInside;
    public bool isHiddenNow;
    public GameObject closedBed;
    public GameObject normalBed;

    // Start is called before the first frame update
    void Start()
    {
        playerInside = false;
        isHiddenNow = false;
        normalBed.SetActive(true);
        closedBed.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && playerInside == true)
        {

            if (isHiddenNow == false)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().enabled = false;
                GameController.Instance.GameStates["CanMove"] = false;
                GameController.Instance.GameStates["isHidden"] = true;
                closedBed.SetActive(true);
                normalBed.SetActive(false);
                isHiddenNow = true;
            }
            else
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().enabled = true;
                GameController.Instance.GameStates["CanMove"] = true;
                GameController.Instance.GameStates["isHidden"] = false;
                closedBed.SetActive(false);
                normalBed.SetActive(true);
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
