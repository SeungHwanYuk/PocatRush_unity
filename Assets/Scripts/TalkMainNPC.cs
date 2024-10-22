using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class TalkMainNPC : MonoBehaviour
{
    // text 舛税
    public Text dialogText;
    public string dialogue;
    public int count = 0;
    public GameObject itemPanel;
    public GameObject churuGet;

    // Event 曽戟獣 須採 敗呪 硲窒
    public UnityEvent onDialogFinished;
    // Start is called before the first frame update

    // 蕉艦五戚芝 硲窒
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

        dialogue = "穴欠偶虞~";
        } else if( count == 1)
        {
            dialogue = "鋳牽股壱 粛雁~";
        } else if(count == 2)
        {
            dialogue = "格亀 鋳牽 股聖掘?";
        } else if(count == 3)
        {
            dialogue = "図楕 雌舘税 鋳牽 焼戚嬬聖 刊牽檎\n端径戚 噺差吉陥姥!";
        }
        else if(count == 4)
        {
            dialogue = "戚薦 錘疑 伸宿備 馬姥\n惟績 馬君 亜澗闇 嬢凶??";
        }
        else if(count == 5)
        {
            dialogue = "壕壱覗艦猿\n源 杏走 源焼匝掘?";
        } else if(count == 6)
        {
            dialogue = "源獣徹走 源虞艦猿???";
        } else if(count == 7)
        {
            dialogue = "益幻背 !!!";
        } else if(count == 8)
        {
            dialogue = "鎧亜 然陥!!!\n鋳牽 匝砺艦猿 煽軒亜ばばば";
            itemPanel.GetComponent<ItemController>().ChuruCount = itemPanel.GetComponent<ItemController>().ChuruCount + 1;
            churuGet.SetActive(true);
        } else if(count >= 9)
        {
            dialogue = "ばばばばば";
        }
       

        // 坪欠鴇 : 据馬澗 獣娃幻鏑 渠傾戚 旋遂 亜管
        // yield 人 敗臆 紫遂喫
        StartCoroutine(Typing(dialogue));

        

        animator.Play(hiAnime);


    }

    // 企鉢 曽戟 敗呪
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
            // 廃越切梢 蓄亜鞠悟 左食像
            dialogText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
        // TODO 
        yield return new WaitForSeconds(1f);
        FinishDialog();
        count++;
    }
}
