using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class GameManager : MonoBehaviour
{
    public Text nickNameText;
    public Text hpText;
    public Text levelText;

    [DllImport("__Internal")]
    private static extern void WorldReadyExtern();
    [DllImport("__Internal")]
    private static extern void HpUpdateExtern(int newHp);


    // Start is called before the first frame update
    void Start()
    {
#if UNITY_WEBGL == true && UNITY_EDITOR == false
        WorldReadyExtern();
#endif

    }

    public void GetNickName(string nickName)
    {  
        nickNameText.text = nickName;
    }
    public void GetHp(int hp)
    {
        hpText.text = hp.ToString();
    }
    public void GetLevel(string level)
    {
        levelText.text = level;  
    }

    public void HpUpdate()
    {
        int nowHp = int.Parse(hpText.text);
        int newHp = nowHp - 1;
        hpText.text = newHp.ToString();
#if UNITY_WEBGL == true && UNITY_EDITOR == false 
        HpUpdateExtern(newHp);
#endif

    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
}
