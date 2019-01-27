using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateZahlen : MonoBehaviour
{

    public GameObject Zahlen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Zahlen.GetComponent<Zahlenschloss>().Toggle();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Zahlen.GetComponent<Zahlenschloss>().Toggle();
    }
}
