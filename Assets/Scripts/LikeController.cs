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

    public int liked = 0;

    // Start is called before the first frame update
    void Start()
    {
        
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
    SaveLikeToReactExtern ("MainNPC", liked);
#endif
    }
}
