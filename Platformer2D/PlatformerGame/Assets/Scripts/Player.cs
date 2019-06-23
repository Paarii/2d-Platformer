using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller_Ref;

    //Movement Varaiables
    public float moveSpeed = 40f;
    private float horizontalAxis;
    public bool isJump = false;
    public Menuhandler playerHandle;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHandle.Moving == true)
        {
            horizontalAxis = Input.GetAxisRaw("Horizontal") * moveSpeed;
            animator.SetFloat("Speed",Mathf.Abs(horizontalAxis));
        }
        if(playerHandle.Jumping == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("isJumping", true);
                isJump = true;
                
            }
            
        }
       
       
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    private void FixedUpdate()
    {
        controller_Ref.Move(horizontalAxis * Time.fixedDeltaTime, false, isJump);
        isJump = false;
        

    }
}
