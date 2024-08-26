using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class CreateCharacterController : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void CreateCharacterExtern(string nickName);


    public Text inputNickname;
    public GameObject startButton;
    private bool isShow;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        startButton.SetActive(isShow);
        
    }

    public void Show()
    {
        
        isShow = true;

     
    }

    public void Create()
    {
        print(inputNickname.text);
#if UNITY_WEBGL == true && UNITY_EDITOR == false
        CreateCharacterExtern(inputNickname.text);
#endif
        Show();
    }
}
