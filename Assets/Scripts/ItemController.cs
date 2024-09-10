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
        userPanel = GameObject.FindGameObjectWithTag("UserPanel");
    }

    // Update is called once per frame
    void Update()
    {
        userHp = int.Parse(userPanel.GetComponent<GameManager>().hpText.text);

        ChuruText.text = ChuruCount.ToString();
        CoinText.text = CoinCount.ToString();

    }

    public void useChuru()
    {
        if(ChuruCount <= 0)
        {
            print("츄르 없음!");
            return;
        }
        userPanel.GetComponent<GameManager>().hpText.text = (userHp + 1).ToString();
        ChuruCount = ChuruCount - 1;
    }

    public void useCoin()
    {
        if (CoinCount <= 0)
        {
            print("코인 없음!");
            return;
        }
        
        CoinCount = CoinCount - 1;
    }

    public void GetChuruValueByCharacter(int churu)
    {
        ChuruCount = churu;      
    }

    public void GetCoinValueByCharacter(int coin)
    {    
        CoinCount = coin;
    }
}
