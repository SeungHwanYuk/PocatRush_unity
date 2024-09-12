using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class TalkMainNPC : MonoBehaviour
{
    // text 정의
    public Text dialogText;
    public string dialogue;
    public int count = 0;
    public GameObject itemPanel;
    public GameObject churuGet;

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
        dialogText.text = "";
        if(count == 0)
        {

        dialogue = "룰루랄라~";
        } else if( count == 1)
        {
            dialogue = "츄르먹고 싶당~";
        } else if(count == 2)
        {
            dialogue = "너도 츄르 먹을래?";
        } else if(count == 3)
        {
            dialogue = "왼쪽 상단의 츄르 아이콘을 누르면\n체력이 회복된다구!";
        }
        else if(count == 4)
        {
            dialogue = "이제 운동 열심히 하구\n게임 하러 가는건 어때??";
        }
        else if(count == 5)
        {
            dialogue = "배고프니까\n말 걸지 말아줄래?";
        } else if(count == 6)
        {
            dialogue = "말시키지 말라니까???";
        } else if(count == 7)
        {
            dialogue = "그만해 !!!";
        } else if(count == 8)
        {
            dialogue = "내가 졌다!!!\n츄르 줄테니까 저리가ㅠㅠㅠ";
            itemPanel.GetComponent<ItemController>().ChuruCount = itemPanel.GetComponent<ItemController>().ChuruCount + 1;
            churuGet.SetActive(true);
        } else if(count >= 9)
        {
            dialogue = "ㅠㅠㅠㅠㅠ";
        }
       

        // 코루틴 : 원하는 시간만큼 딜레이 적용 가능
        // yield 와 함께 사용됨
        StartCoroutine(Typing(dialogue));

        

        animator.Play(hiAnime);


    }

    // 대화 종료 함수
    public void FinishDialog()
    {
        animator.Play(stayAnime);
        gameObject.SetActive(false);
        StopAllCoroutines();
        
        onDialogFinished.Invoke();
        
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
        count++;
    }
}
