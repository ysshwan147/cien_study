using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Comtroller : MonoBehaviour
{
    [SerializeField]
    public CharacterController controller;


    public float walkSpeed = 1.5f;
    public float jumpSpeed = 1;
    public float gravityScale = 1;
    public bool canjump = true;
    public bool isGrounded = true;

    public SpriteRenderer renderer;

    bool inputJumpStart = false;

    Vector2 input = default(Vector2);
    Vector3 velocity = default(Vector2);
    // Start is called before the first frame update
    void Start()
    {
        if (controller == null)
            controller = GetComponent<CharacterController>();
        renderer = GetComponent<SpriteRenderer>();
    }



    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
        inputJumpStart = Input.GetButtonDown("Jump");

        if (input.x != 0)
        {
            if (input.x > 0)
                renderer.flipX = true;
            else
                renderer.flipX = false;

            velocity.x = walkSpeed * input.x * 0.1f;
        }

        if (!isGrounded)
        {
            velocity.y -= gravityScale * Time.deltaTime;
        }

        if (isGrounded && inputJumpStart)
        {
           // velocity.y = 0;
            velocity.y += (jumpSpeed * 0.1f);
        }


        controller.Move(velocity);
    }
}
