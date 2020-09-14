using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    Animator animator;

    [SerializeField]
    private GameObject moveStart;
    [SerializeField]
    private GameObject moveGoal;

    private bool isMoving = false;
    public float moveSpeed = 1.0f;
    private float moveTimer = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Run", true);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Jump", true);
            isMoving = true;
        }

        if (!isMoving) {
            moveStart.transform.position = transform.position;
            moveGoal.transform.position = transform.position + transform.forward * 1.75f;
        }
        else
        {
            moveTimer += Time.deltaTime;
            float location = moveTimer * moveSpeed / 1.75f;
            transform.position = Vector3.Lerp(moveStart.transform.position, moveGoal.transform.position, location);

            if (transform.position == moveGoal.transform.position)
            {
                animator.SetBool("Jump", false);
                isMoving = false;
                moveTimer = 0f;
            }
        }


    }


    public void OnCallChangeFace()
    {

    }
}
