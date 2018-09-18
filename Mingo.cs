using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mingo : MonoBehaviour
{
    private Animator anim;
    public float walkSpeed;
    public float runSpeed;
    public float turnSpeed;
    public float jumpSpeed;
    [Range(0.01f, 1f)]
    public static Rigidbody rb;
    bool isColliding = false;
    bool disableJump = false;

    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    Vector3 previousMoveDirection;
    void FixedUpdate()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey("w"))
        {
            if (isColliding)
                  Floor.SpawnTrees(rb.position);

            anim.SetInteger("AnimPar", 1);
            moveDirection = transform.forward * walkSpeed * Input.GetAxis("Vertical");
            previousMoveDirection = moveDirection;

            if (Input.GetKey("left shift"))
            {
                anim.SetInteger("AnimPar", 2);
                moveDirection = transform.forward * runSpeed * Input.GetAxis("Vertical");
            }
        }
        else
        {
            anim.SetInteger("AnimPar", 0);
        }


        if (!disableJump)
        {
            if (Input.GetKey("space"))
            {
                rb.AddForce(Vector3.up * jumpSpeed, ForceMode.VelocityChange);
                disableJump = true;
                StartCoroutine(ActivateJumpDelayed());
            }

        }


        rb.MoveRotation(Quaternion.Euler(0, rb.rotation.eulerAngles.y + (Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime), 0));
        rb.MovePosition(rb.position + moveDirection);

        isColliding = false;

    }

    private void OnCollisionStay(Collision collision)
    {
        isColliding = true;
    }

    IEnumerator ActivateJumpDelayed()
    {
        yield return new WaitForSeconds(1);
        disableJump = false;
    }


    public static void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}