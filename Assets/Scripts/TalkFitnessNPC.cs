using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TalkFitnessNPC : MonoBehaviour
{

    public GameObject talkPanel;
    public GameObject nextButton;
    public GameObject goMainButton;
    public GameObject askButton;
    public GameObject exitButton;

    int clickCount = 0;
    int talkWayCount = 0;


    // text ����
    public Text dialogText;
    public string dialogue;

    // Event ����� �ܺ� �Լ� ȣ��
    public UnityEvent onDialogFinished;
    // Start is called before the first frame update

    // �ִϸ��̼� ȣ��
    public GameObject npc;
    public GameObject player;
    Animator animator;

    public string stayAnime = "NPCStay";
    public string hiAnime = "NPCHi";
    public string byeAnime = "NPCBye";


    public void StartDialog()
    {
        animator = npc.GetComponent<Animator>();
        // ù ���
        dialogue = "����?";
        
        // �ڷ�ƾ : ���ϴ� �ð���ŭ ������ ���� ����
        // yield �� �Բ� ����
        StartCoroutine(Typing(dialogue));

        animator.Play(hiAnime);
        askButton.SetActive(false);

    }

    // ��ȭ ���� �Լ�
    public void FinishDialog()
    {
        
        animator.Play(byeAnime);
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
            // �ѱ��ھ� �߰��Ǹ� ������
            dialogText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
        // Ÿ������ ������ ����
        yield return new WaitForSeconds(0.7f);
        nextButton.SetActive(true);

        // ��ȭ �б���
        if(clickCount == 2 && talkWayCount == 0)
        {
        askButton.SetActive(true);
            exitButton.SetActive(true);
            
        }

    }


    // Update is called once per frame
    void Update()
    {
            if (clickCount == 0 && talkWayCount == 0)
            {
            exitButton.SetActive(false);
            dialogue = "ó������ �ΰ��ε�...";
        }
            else if (clickCount == 1 && talkWayCount == 0)
            {
            
            dialogue = "���� ���Ϸ� �°ž�?\n��ϰ� ������ ���� �ϴ���!";
            }
            else if ( clickCount == 2 && talkWayCount == 0)
        {
            nextButton.SetActive(false);
        }

        // �б��� 1
        if (clickCount == 2 && talkWayCount == 1)
        {
            exitButton.SetActive(false);
            dialogue = "�ΰ����迡�� ����ϸ�\n���Ͽ����� ����ġ�� �ö󰣴ٴ���...?";
        } else if(clickCount == 3 && talkWayCount == 1)
        {
            dialogue = "�ｺ��ȿ��ִ� ��ⱸ�� ��ȣ�ۿ��ϸ�\n���� ������ �����ž�!";
        }
        else if (clickCount == 4 && talkWayCount == 1)
        {
            dialogue = "���� �Ȱ��� ����?";
        }
        else if (clickCount == 5 && talkWayCount == 1)
        {
            nextButton.SetActive(false);
            exitButton.SetActive(true);
        }

    }

    public void askCountPlus()
    {
        // �б��� ���۽� ù ���� ����
        dialogue = "�װ� ����Ʈ��ġ�ݾ�?";

        nextButton.SetActive(false);
        talkWayCount++;
        print(talkWayCount+ " : talkWayCount");
        dialogText.text = "";
        StartCoroutine(Typing(dialogue));

        // �÷��̾� ��ȭ �ִϸ��̼� ����
        player.GetComponent<MyPlayer>().playTalkingAnime();
        
    }
    public void countPlus()
    {
        nextButton.SetActive(false);
        clickCount++;
        print(clickCount + " : clickCount");
        dialogText.text = "";
        StartCoroutine(Typing(dialogue));  
    }

    

}
