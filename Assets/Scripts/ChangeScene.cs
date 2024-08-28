using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 씬을 변경할 때 필요
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{

    public string sceneName; // 불러올 씬

    public Text welcomeText;
    public GameObject createPanel;
    public GameObject gameStartButton;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void isUser(string nickName)
    {
        createPanel.SetActive(false);
        gameStartButton.SetActive(true);
        welcomeText.text = "<color=yellow>" + nickName + "</color>" + "님 어서오시게.";
    }

    // 씬 불러오기
    public void Load()
    {
        SceneManager.LoadScene(sceneName);
    }
}