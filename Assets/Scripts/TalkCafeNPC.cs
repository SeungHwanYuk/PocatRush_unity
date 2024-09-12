using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TalkCafeNPC : MonoBehaviour
{

    public GameObject talkPanel;
    public GameObject nextButton;
    public GameObject goMainButton;
    /*public GameObject askButton;*/
    public GameObject exitButton;
    public GameObject shopButton;

    int clickCount = 0;
    int talkWayCount = 0;


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
  

    public void StartDialog()
    {
        animator = npc.GetComponent<Animator>();
        // 첫 대사
        dialogue = "으앙ㅠㅠ";
        
        // 코루틴 : 원하는 시간만큼 딜레이 적용 가능
        // yield 와 함께 사용됨
        StartCoroutine(Typing(dialogue));

        animator.Play(hiAnime);
        shopButton.SetActive(false);

    }

    // 대화 종료 함수
    public void FinishDialog()
    {  
        clickCount = 0;
        talkWayCount = 0;
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

        /*// 대화 분기점
        if (clickCount == 2 && talkWayCount == 0)
        {
            askButton.SetActive(true);
            exitButton.SetActive(true);

        }*/

    }


    // Update is called once per frame
    void Update()
    {
            if (clickCount == 0 && talkWayCount == 0)
            {
            exitButton.SetActive(false);
            dialogue = "손이 짧아서 컵이 닦이지 않아ㅠ";
        }
            else if (clickCount == 1 && talkWayCount == 0)
            {
            
            dialogue = "어쩌지....";
            }
            else if ( clickCount == 2 && talkWayCount == 0)
        {
            nextButton.SetActive(false);
            exitButton.SetActive(true);
            shopButton.SetActive(true);
        }

       /* // 분기점 1
        if (clickCount == 2 && talkWayCount == 1)
        {
            exitButton.SetActive(false);
            dialogue = "인간세계에서 운동을하면\n포켓월드의 경험치가 올라간다던데...?";
        }
        else if (clickCount == 3 && talkWayCount == 1)
        {
            dialogue = "헬스장안에있는 운동기구와 상호작용하면\n너의 레벨이 오를거야!";
        }
        else if (clickCount == 4 && talkWayCount == 1)
        {
            dialogue = "빨리 안가고 뭐해?";
        }
        else if (clickCount == 5 && talkWayCount == 1)
        {
            nextButton.SetActive(false);
            exitButton.SetActive(true);
        }*/

    }

   /* public void askCountPlus()
    {
        // 분기점 시작시 첫 문장 지정
        dialogue = "그건 스마트워치잖아?";
        nextButton.SetActive(false);
        talkWayCount++;
        print(talkWayCount+ " : talkWayCount");
        dialogText.text = "";
        StartCoroutine(Typing(dialogue));
    }*/
    public void countPlus()
    {
        nextButton.SetActive(false);
        clickCount++;
        print(clickCount + " : clickCount");
        dialogText.text = "";
        StartCoroutine(Typing(dialogue));  
    }

    

}
