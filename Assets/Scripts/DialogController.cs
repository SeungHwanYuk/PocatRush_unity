using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class DialogController : MonoBehaviour
{
    public Text dialogText;

    public UnityEvent onDialogFinished;
    // Start is called before the first frame update
    public void StartDialog()
    {
        dialogText.text = "";
        string sampleText = "안녕하세요. 플레이어님,\nPocat Rush에 오신 것을 환영합니다\n 룰루라라\n\n\n\n 재호야 뭘봐?";
        StartCoroutine(Typing(sampleText));
    }

    public void FinishDialog()
    {
        gameObject.SetActive(false);
        StopAllCoroutines();
        
        onDialogFinished.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Typing(string text)
    {
        foreach(char letter in text.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
        // TODO 
        yield return new WaitForSeconds(1f);
        FinishDialog();
    }
}
