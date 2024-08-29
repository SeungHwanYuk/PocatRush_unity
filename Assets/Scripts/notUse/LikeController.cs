using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;


public class LikeController : MonoBehaviour
{
[DllImport("__Internal")]
private static extern void SaveLikeToReactExtern(string npcName, int liked);

    public Text showLiked;
    public Button likeButton;

    public GameObject npc;
    public int liked = 0;

    private string npcName;

    // Start is called before the first frame update
    void Start()
    {
       
        npcName = npc.name;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void likeCount()
    {
        
        liked++;
        showLiked.text = "¢½ : " + liked;
#if UNITY_WEBGL == true && UNITY_EDITOR == false
    SaveLikeToReactExtern (npcName, liked);
#endif
    }
}
