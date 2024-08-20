using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class DialogController : MonoBehaviour
{
    // text 정의
    public Text dialogText;

    // Event 종료시 외부 함수 호출
    public UnityEvent onDialogFinished;
    // Start is called before the first frame update
    public void StartDialog()
    {
        dialogText.text = "";
        string sampleText = "재호야 일해라\n\n\n룰루라라\n\n\n\n 뭘봐?";
        // 코루틴 : 원하는 시간만큼 딜레이 적용 가능
        // yield 와 함께 사용됨
        StartCoroutine(Typing(sampleText));

    }

    // 대화 종료 함수
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
            // 한글자씩 추가되며 보여짐
            dialogText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
        // TODO 
        yield return new WaitForSeconds(1f);
        FinishDialog();
    }
}
