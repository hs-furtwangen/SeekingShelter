﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetAxis("Fire1") > 0)
        {
            if (collision.gameObject.tag == "Interactable")
            {
                collision.gameObject.GetComponent<Interactable>().Interact();
            }
        }
    }
}
