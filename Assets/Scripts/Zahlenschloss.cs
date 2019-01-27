using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zahlenschloss : MonoBehaviour
{
    int fieldOneValue;
    int fieldTwoValue;
    int fieldThreeValue;
    int fieldFourValue;

    public Text fieldOne;
    public Text fieldTwo;
    public Text fieldThree;
    public Text fieldFour;

    bool isVisible;
    public GameObject ZahlenschlossUi;

    // Start is called before the first frame update
    void Start()
    {
        fieldOneValue = Random.Range(0, 9);
        if (fieldOneValue == 4)
        {
            fieldOneValue = Random.Range(0,9);
        }
        fieldOne.text = fieldOneValue.ToString();

        fieldTwoValue = Random.Range(0, 9);
        if (fieldTwoValue == 1)
        {
            fieldTwoValue = Random.Range(0, 9);
        }
        fieldTwo.text = fieldTwoValue.ToString();

        fieldThreeValue = Random.Range(0, 9);
        if (fieldThreeValue == 6)
        {
            fieldThreeValue = Random.Range(0, 9);
        }
        fieldThree.text = fieldThreeValue.ToString();

        fieldFourValue = Random.Range(0, 9);
        if (fieldFourValue == 9)
        {
            fieldFourValue = Random.Range(0, 9);
        }
        fieldFour.text = fieldFourValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (isVisible == true)
        {
            ZahlenschlossUi.SetActive(true);
        } else
        {
            ZahlenschlossUi.SetActive(false);
        }

        if (Input.GetKeyUp("y"))
        {
            Toggle();
        }

        if (((fieldOneValue == 4 && fieldTwoValue == 1) && fieldThreeValue == 6) && fieldFourValue == 9)
        {
            Debug.Log("All Numbers are correct");
            GameController.Instance.GameStates["hasFinalKey"] = true;
        }
    }

    public void AddFieldOne()
    {
        fieldOneValue++;
        if (fieldOneValue > 9)
        {
            fieldOneValue = 0;
        }
        fieldOne.text = fieldOneValue.ToString();
    }

    public void TakeFieldOne()
    {
        fieldOneValue--;
        if (fieldOneValue < 0)
        {
            fieldOneValue = 9;
        }
        fieldOne.text = fieldOneValue.ToString();
    }

    public void AddFieldTwo()
    {
        fieldTwoValue++;
        if (fieldTwoValue > 9)
        {
            fieldTwoValue = 0;
        }
        fieldTwo.text = fieldTwoValue.ToString();
    }

    public void TakeFieldTwo()
    {
        fieldTwoValue--;
        if (fieldTwoValue < 0)
        {
            fieldTwoValue = 9;
        }
        fieldTwo.text = fieldTwoValue.ToString();
    }

    public void AddFieldThree()
    {
        fieldThreeValue++;
        if (fieldThreeValue > 9)
        {
            fieldThreeValue = 0;
        }
        fieldThree.text = fieldThreeValue.ToString();
    }

    public void TakeFieldThree()
    {
        fieldThreeValue--;
        if (fieldThreeValue < 0)
        {
            fieldThreeValue = 9;
        }
        fieldThree.text = fieldThreeValue.ToString();
    }

    public void AddFieldFour()
    {
        fieldFourValue++;
        if (fieldFourValue > 9)
        {
            fieldFourValue = 0;
        }
        fieldFour.text = fieldFourValue.ToString();
    }

    public void TakeFieldTFour()
    {
        fieldFourValue--;
        if (fieldFourValue < 0)
        {
            fieldFourValue = 9;
        }
        fieldFour.text = fieldFourValue.ToString();
    }

    public void Toggle()
    {
        isVisible = !isVisible;
    }
}
