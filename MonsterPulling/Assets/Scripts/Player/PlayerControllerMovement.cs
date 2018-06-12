using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerControllerMovement : MonoBehaviour {

    private Animator animator;
    private FirstPersonController characterController;
    private Vector2 moveInput;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        characterController = GetComponent<FirstPersonController>();
        
    }

    private void Update()
    {

        moveInput = characterController.m_Input;
        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        animator.SetFloat("Vertical", moveInput.y);
        animator.SetFloat("Horizontal", moveInput.x);
    }
}
