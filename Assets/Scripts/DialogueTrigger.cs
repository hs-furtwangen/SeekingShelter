using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public float delay = 0.1f;
    public string fullText;
    private string currentText= "";

    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowDialogue()); 
    }

    IEnumerator ShowDialogue()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0,i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
}
