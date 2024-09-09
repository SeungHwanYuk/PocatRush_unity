using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{

    public Text ChuruText;
    public Text CoinText;

    public int ChuruCount;
    public int CoinCount;
    public int userHp;

    public GameObject userPanel;


    // Start is called before the first frame update
    void Start()
    {
        // 서버에서 받아온다는 가정
        ChuruText.text = 3.ToString();
        CoinText.text = 3.ToString();


        userPanel = GameObject.FindGameObjectWithTag("UserPanel");
    }

    // Update is called once per frame
    void Update()
    {
        userHp = int.Parse(userPanel.GetComponent<GameManager>().hpText.text);
        ChuruCount = int.Parse(ChuruText.text);
        CoinCount = int.Parse(CoinText.text);
        
    }

    public void useChuru()
    {
        if(ChuruCount <= 0)
        {
            print("츄르 없음!");
            return;
        }
        userPanel.GetComponent<GameManager>().hpText.text = (userHp + 1).ToString();
        ChuruText.text = (ChuruCount - 1).ToString();
    }
}
