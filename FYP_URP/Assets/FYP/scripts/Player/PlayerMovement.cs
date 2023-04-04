using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour, IDataPersistence
{
    [Header("Movement")]
    public float moveSpeed;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [SerializeField] GameObject PlayerBody;
    [SerializeField] Animator anim;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public bool canMove = true;

    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
    }

    public void SaveData(GameData data)
    {
        data.playerPosition = this.transform.position;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        MyInput();
        SpeedControl();

        rb.drag = 5;
        if (canMove)
        {
            #region Rotation
            if (Input.GetKey(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.D))
                {
                    RotationDirector(45f);
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    RotationDirector(-45f);
                }
                else
                {
                    RotationDirector(0f);
                }
            }
            if (Input.GetKey(KeyCode.A))
            {

                if (Input.GetKey(KeyCode.W))
                {
                    RotationDirector(-45f);
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    RotationDirector(-135f);
                }
                else
                {
                    RotationDirector(-90f);
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                if (Input.GetKey(KeyCode.S))
                {
                    RotationDirector(135f);
                }
                else if (Input.GetKey(KeyCode.W))
                {
                    RotationDirector(45f);
                }
                else
                {
                    RotationDirector(90f);
                }
            }
            if (Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.D))
                {
                    RotationDirector(135f);
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    RotationDirector(-135f);
                }
                else
                {
                    RotationDirector(180f);
                }
            }
            #endregion
        }
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            MovePlayer();
        }
    }

    private void MyInput()
    {
        if (canMove)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");

            if(horizontalInput != 0 || verticalInput != 0)
            {
                anim.SetBool("isWalking", true);
            }
            else
            {
                anim.SetBool("isWalking", false);
            }
        }


    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

    }
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void RotationDirector(float rotY)
    {
        
            PlayerBody.transform.rotation = Quaternion.Euler(0, rotY, 0);
        
    }
}