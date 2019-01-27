using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventar : MonoBehaviour
{

    public GameObject FirstItemSlot;
    public GameObject FirstNumberSlot;
    public GameObject SecondItemSlot;
    public GameObject SecondNumberSlot;
    public GameObject ThirdItemSlot;
    public GameObject ThirdNumberSlot;
    public GameObject FourthNumberSlot;
    public GameObject FinalKeySlot;

    // Start is called before the first frame update
    void Start()
    {
        FirstItemSlot.SetActive(false);
        FirstNumberSlot.SetActive(false);
        SecondItemSlot.SetActive(false);
        SecondNumberSlot.SetActive(false);
        ThirdItemSlot.SetActive(false);
        ThirdNumberSlot.SetActive(false);
        FourthNumberSlot.SetActive(false);
        FinalKeySlot.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.Instance.GameStates["hasFirstQuestItem"] == true)
        {
            FirstItemSlot.SetActive(true);
        } else
        {
            FirstItemSlot.SetActive(false);
        }

        if (GameController.Instance.GameStates["hasFirstNumber"] == true)
        {
            FirstNumberSlot.SetActive(true);
        }
        else
        {
            FirstNumberSlot.SetActive(false);
        }


        if (GameController.Instance.GameStates["hasSecondQuestItem"] == true)
        {
            SecondItemSlot.SetActive(true);
        }
        else
        {
            SecondItemSlot.SetActive(false);
        }

        if (GameController.Instance.GameStates["hasSecondNumber"] == true)
        {
            SecondNumberSlot.SetActive(true);
        }
        else
        {
            SecondNumberSlot.SetActive(false);
        }


        if (GameController.Instance.GameStates["hasThirdQuestItem"] == true)
        {
            ThirdItemSlot.SetActive(true);
        }
        else
        {
            ThirdItemSlot.SetActive(false);
        }

        if (GameController.Instance.GameStates["hasThirdNumber"] == true)
        {
            ThirdNumberSlot.SetActive(true);
        }
        else
        {
            ThirdNumberSlot.SetActive(false);
        }

        if (GameController.Instance.GameStates["hasFourthNumber"] == true)
        {
            FourthNumberSlot.SetActive(true);
        }
        else
        {
            FourthNumberSlot.SetActive(false);
        }

        if (GameController.Instance.GameStates["hasFinalKey"] == true)
        {
            FinalKeySlot.SetActive(true);
        }
        else
        {
            FinalKeySlot.SetActive(false);
        }
    }
}
