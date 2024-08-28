using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class CreateCharacterController : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void CreateCharacterExtern(string nickName);

    [DllImport("__Internal")]
    private static extern void GameReadyExtern(string gameReady);


    public Text inputNickname;
    public GameObject startButton;
    public GameObject isBlankText;
    public GameObject createButton;

    public Text nickNameOverlap;

    private bool startShow;
    private bool isBlankShow;

    // Start is called before the first frame update
    void Start()
    {
        isBlankText.SetActive(false);
#if UNITY_WEBGL == true && UNITY_EDITOR == false
        GameReadyExtern("게임 준비 완료");
#endif

    }

    // Update is called once per frame
    void Update()
    {
        isBlankText.SetActive(isBlankShow);
        if(inputNickname.text == "")
        {
            isBlankShow = true;
        } else
        {
            isBlankShow = false;
        }
  
    }

    public void nickNameFound()
    {
        nickNameOverlap.text = "중복된 닉네임입니다.";
        Invoke("nickNameFoundHide", 2.0f);
    }

   

    public void Show()
    {
       
        startButton.SetActive(true);
        createButton.SetActive(false);
    }

    public void isBlank()
    {

        isBlankShow = true;
    }
    public void nickNameFoundHide()
    {
        nickNameOverlap.text = "";
    }


    public void Create()
    {
        print(inputNickname.text);
#if UNITY_WEBGL == true && UNITY_EDITOR == false
        CreateCharacterExtern(inputNickname.text);
#endif
        
    }
}
