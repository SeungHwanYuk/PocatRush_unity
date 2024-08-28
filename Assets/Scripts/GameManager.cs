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
        hpText.text = "HP : " + hp.ToString();
    }
    public void GetLevel(string level)
    {
        levelText.text = level;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
}
