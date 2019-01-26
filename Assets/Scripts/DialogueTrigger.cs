using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public float delay = 0.1f;
    public string fullText;
    private string currentText= "";
    public GameObject textBox;
    public Text textMessage;
    public string[] MessageCollection;
    private bool interactable;



    private bool isOpen;
    
    

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        interactable = true;
        textBox.SetActive(false);
        
    }

    void Update()
    {
        if (Input.GetKeyUp("space") && isOpen == true)
        {
            CloseTextBox();
        }
        if (Input.GetKeyDown("space") && isOpen == false)
        {
            OpenTextBox();            
        }
    }

    IEnumerator ShowDialogue()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0,i);
            textMessage.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        isOpen = true;
        interactable = true;
    }

    public void OpenTextBox()
    {
        if (interactable == true)
        {
            textBox.SetActive(true);
            StartCoroutine(ShowDialogue());
            interactable = false;
        }
    }

    public void CloseTextBox()
    {
        textBox.SetActive(false);
        isOpen = false;
    }

    public void ChangeDisplayedText(int i)
    {
        fullText = MessageCollection[i];
    }
}
