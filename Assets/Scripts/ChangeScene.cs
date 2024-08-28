using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ���� ������ �� �ʿ�
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{

    public string sceneName; // �ҷ��� ��

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
        welcomeText.text = "<color=yellow>" + nickName + "</color>" + "�� ����ð�.";
    }

    // �� �ҷ�����
    public void Load()
    {
        SceneManager.LoadScene(sceneName);
    }
}