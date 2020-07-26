
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
   private bool onGround;
   private float jumpPressure;
   private float minJump;
   private float maxJumpPressure;
   private Rigidbody rbody;
   private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        onGround = true;
        jumpPressure = 0f;
        minJump = 2f;
        maxJumpPressure = 10f;
        rbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      if(onGround)  
      {
          //hoding jump button//
          if(Input.GetButton("Jump"))
          {
            if(jumpPressure < maxJumpPressure)
            {
                jumpPressure += Time.deltaTime*10f;
            }
            else
            {
                jumpPressure = maxJumpPressure;  
            }
            anim.SetFloat("jumpPressure",jumpPressure + minJump);
            anim.speed = 1f + (jumpPressure/10);
            
          }
          //not holding jump button//
          else
          {
              //jump//
              if(jumpPressure > 0f)
              {
                  jumpPressure = jumpPressure + minJump;
                  rbody.velocity = new Vector3(jumpPressure/10f,jumpPressure,0f);
                  jumpPressure = 0f;
                  onGround = false;
                  anim.SetFloat("jumpPressure",0f);
                  anim.SetBool("onGround",onGround);
                  anim.speed = 1f;
              }
          }
      }
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("ground"))
        {
            onGround = true;
            anim.SetBool("onGround",onGround);
        }
    }
}

