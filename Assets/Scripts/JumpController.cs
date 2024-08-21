using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class JumpController : MonoBehaviour
{
    [SerializeField]
    public float jumpPower = 4f;

    Rigidbody rbody;
    public LayerMask groundLayer;

    bool goJump = false;
    bool onGround = false;
    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            
            Jump();  //점프
        }

    }

    private void FixedUpdate()
    {
        //착지판정
        onGround = Physics.Linecast(transform.position,
                                       transform.position - (transform.up * 0.5f), 
                                       groundLayer);
        
        if (onGround && goJump)
        {
            print("점프!");
            Vector3 jumpPw = new Vector3(0, jumpPower);
            rbody.AddForce(jumpPw, ForceMode.Impulse);
            goJump = false;
        }
    }

    public void Jump()
    {
        goJump = true;
    }
}
