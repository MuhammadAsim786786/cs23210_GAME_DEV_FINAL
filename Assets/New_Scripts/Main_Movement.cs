using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Movement : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public BoxCollider2D standingCollider;
    private Rigidbody2D rb;
    private bool isJumping = false;
    private bool isCrouching = false;
    private Player1Controller playerController;
    private Player_Combat playerCombat;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerController = GetComponent<Player1Controller>();
        playerCombat = GetComponent<Player_Combat>(); 
    }

    

    void Update()
    {
        float moveDirection = 0f;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection = 1f;
            transform.Translate(new Vector2(0.4f, 0) * moveSpeed * Time.deltaTime);
            if (!isCrouching) playerController.Run();
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection = -1f;
            transform.Translate(new Vector2(-0.4f, 0) * moveSpeed * Time.deltaTime);
            if (!isCrouching) playerController.Run();
        }
        else
        {
            playerController.RunOff();
        }
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            rb.AddForce(new Vector2(0, 200));
            playerController.Jump();
            StartCoroutine(ResetJump());
        }
        if (Input.GetKey(KeyCode.C) && !isCrouching)
        {
            Crouch();
        }
        else if (Input.GetKeyUp(KeyCode.C) && isCrouching)
        {
            StandUp();
        }
    }

    void Crouch()
    {
        isCrouching = true;
        if (standingCollider != null)
        {
            standingCollider.enabled = false;
        }

        playerController.Walk();
    }

    void StandUp()
    {
        isCrouching = false;
        if (standingCollider != null)
        {
            standingCollider.enabled = true;
        }
        playerController.WalkOff();
    }

    IEnumerator ResetJump()
    {
        yield return new WaitForSeconds(1f);
        isJumping = false;
        playerController.JumpOff();
    }
}