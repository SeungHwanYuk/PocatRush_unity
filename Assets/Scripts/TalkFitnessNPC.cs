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


    // text ����
    public Text dialogText;
    public string dialogue;

    // Event ����� �ܺ� �Լ� ȣ��
    public UnityEvent onDialogFinished;
    // Start is called before the first frame update

    // �ִϸ��̼� ȣ��
    public GameObject npc;
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

    }

    // ��ȭ ���� �Լ�
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
            // �ѱ��ھ� �߰��Ǹ� ������
            dialogText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
        // Ÿ������ ������ ����
        yield return new WaitForSeconds(0.7f);
        nextButton.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
     
        
            if (clickCount == 0)
            {
            exitButton.SetActive(false);
            dialogue = "���� ���Ϸ� �°ž�?\n��ϰ� ������ ���� �ϴ���!";
   
        }
            else if (clickCount == 1)
            {
            dialogue = "�� �ٹ����?";
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
