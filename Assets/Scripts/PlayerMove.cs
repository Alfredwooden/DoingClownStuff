using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    private CharacterController characterController;
    public float playerSpeed;

    [SerializeField] private float gravity;
    [SerializeField] public float jump;
    private float downwards;
    private AudioSource audioSource;
    private Image playerImage;

    // Jump Checks
    private Transform groundCheck;
    private float groundDistance = 0.4f;
    private LayerMask groundMask;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        groundCheck = GameObject.Find("GroundCheck").transform;
        groundMask = LayerMask.GetMask("Ground");

        gravity = -9.81f;
        downwards = 0;
        jump = 0.5f;

        playerSpeed = 10f;
        characterController = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
        playerImage = GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        // Add downward gravity
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && downwards < 0)
        {
            downwards = -2f;
        }

        // Jump button
        if (Input.GetButtonDown("Jump") && (isGrounded))
        {
            downwards = Mathf.Sqrt(jump * -2f * gravity);
        }

        downwards += gravity * Time.deltaTime;

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), downwards, Input.GetAxis("Vertical"));
        characterController.Move(move * Time.deltaTime * playerSpeed);

        if (Input.GetAxis("Horizontal") > 0)
        {
            playerImage.transform.localScale = new Vector3(1, playerImage.transform.localScale.y, playerImage.transform.localScale.z);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            playerImage.transform.localScale = new Vector3(-1, playerImage.transform.localScale.y, playerImage.transform.localScale.z);
        }

        if (Input.GetKeyDown(KeyCode.Z) && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
