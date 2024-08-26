using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 씬을 변경할 때 필요

public class ChangeScene : MonoBehaviour
{

    public string sceneName; // 불러올 씬

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // 씬 불러오기
    public void Load()
    {
        SceneManager.LoadScene(sceneName);
    }
}