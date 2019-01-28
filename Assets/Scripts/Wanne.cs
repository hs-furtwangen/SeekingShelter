using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanne : MonoBehaviour
{
    public bool playerInside;
    public bool isHiddenNow;
    public GameObject emptyWanne;
    public GameObject volleWanne;

    // Start is called before the first frame update
    void Start()
    {
        playerInside = false;
        isHiddenNow = false;
        volleWanne.SetActive(true);
        emptyWanne.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && playerInside == true)
        {
            if (GameController.Instance.GameStates["hasSecondQuestItem"] == true)
            {
                emptyWanne.SetActive(true);
                volleWanne.SetActive(false);
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
