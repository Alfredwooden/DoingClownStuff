using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController characterController;
    public float playerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 10f;
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        characterController.Move(move*Time.deltaTime*playerSpeed);

    }
}
