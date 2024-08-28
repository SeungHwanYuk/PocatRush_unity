using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TalkFitnessNPC : MonoBehaviour
{

    public GameObject talkPanel;
    public GameObject nextButton;
    public GameObject exitButton;
    int clickCount = 0;


    // text 정의
    public Text dialogText;
    public string dialogue;

    // Event 종료시 외부 함수 호출
    public UnityEvent onDialogFinished;
    // Start is called before the first frame update

    // 애니메이션 호출
    public GameObject npc;
    Animator animator;

    public string stayAnime = "NPCStay";
    public string hiAnime = "NPCHi";
    public string byeAnime = "NPCBye";


    public void StartDialog()
    {
        animator = npc.GetComponent<Animator>();
        // 첫 대사
        dialogue = "뭘봐?";
        
        // 코루틴 : 원하는 시간만큼 딜레이 적용 가능
        // yield 와 함께 사용됨
        StartCoroutine(Typing(dialogue));

        animator.Play(hiAnime);

    }

    // 대화 종료 함수
    public void FinishDialog()
    {
        
        animator.Play(byeAnime);
        clickCount = 0;
        dialogText.text = "";
        talkPanel.SetActive(false);
        StopAllCoroutines();

        onDialogFinished.Invoke();
    }

    public void playbyeAnime()
    {
    }
  
    IEnumerator Typing(string text)
    {
        
        foreach (char letter in text.ToCharArray())
        {
            // 한글자씩 추가되며 보여짐
            dialogText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
        // 타이핑이 끝나면 실행
        yield return new WaitForSeconds(0.7f);
        nextButton.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
     
        
            if (clickCount == 0)
            {
            exitButton.SetActive(false);
            dialogue = "여긴 뭐하러 온거야?\n운동하고 싶으면 들어가서 하던가!";
   
        }
            else if (clickCount == 1)
            {
            dialogue = "뭘 꾸물대니?";
            }
            else if ( clickCount == 2)
        {
            nextButton.SetActive(false);
            exitButton.SetActive(true);
        }

       
    }
    public void countPlus()
    {
        nextButton.SetActive(false);
        clickCount++;
        dialogText.text = "";
        StartCoroutine(Typing(dialogue));
        
    }

    

}
