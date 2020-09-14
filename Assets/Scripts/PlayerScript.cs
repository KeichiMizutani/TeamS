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

    private float panelDistance = 1.75f;
    private GameObject[] panel;
    private RaycastHit mouseCursorHit;
    private RaycastHit mouseClickHit;



    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Run", true);

        panel = new GameObject[4];


        Invoke("PanelChecker", 0.1f);
    }



    private void Update()
    {

        //StagePanelSelect
        Ray mouseCursorRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if(Physics.Raycast(mouseCursorRay,out mouseCursorHit))
        {
            if(mouseCursorHit.collider.gameObject.tag == "Panel")
            {
                if (mouseCursorHit.collider.gameObject.GetComponent<PanelScript>().Selectable)
                {
                    Vector3 targetDir = mouseCursorHit.collider.gameObject.transform.position - transform.position;
                    float targetAngle = Mathf.Atan2(targetDir.z, targetDir.x);
                    targetAngle = -1 * Mathf.Rad2Deg * targetAngle + 90f;
                    transform.rotation = Quaternion.Euler(0, targetAngle, 0);
                    //Click to move
                    if (Input.GetMouseButtonDown(0))
                    {
                        animator.SetBool("Jump", true);
                        isMoving = true;

                        for (int i = 0; i < 4; i++)
                        {
                            if (panel[i] != null)
                            {
                                panel[i].GetComponent<PanelScript>().PanelUP(false);
                            }
                        }
                    }
                }
            }
        }



        if (!isMoving) {
            moveStart.transform.position = transform.position;
            moveGoal.transform.position = transform.position + transform.forward * panelDistance;
        }
        else
        {
            moveTimer += Time.deltaTime;
            float location = moveTimer * moveSpeed / panelDistance;
            transform.position = Vector3.Lerp(moveStart.transform.position, moveGoal.transform.position, location);

            if (transform.position == moveGoal.transform.position)
            {
                PanelChecker();
            }
        }


    }


    void PanelChecker()
    {
        animator.SetBool("Jump", false);
        isMoving = false;
        moveTimer = 0f;

        for (int i = 0; i < 4; i++)
        {
            RaycastHit hitInfo;

            if (Physics.Raycast(new Vector3(transform.position.x + panelDistance * Mathf.Cos(i * Mathf.PI / 3), transform.position.y + 2f, transform.position.z + panelDistance * Mathf.Sin(i * Mathf.PI / 3)),
                Vector3.down, out hitInfo, 20f))
            {
                panel[i] = hitInfo.collider.gameObject;
                panel[i].GetComponent<PanelScript>().PanelUP(true);
            }
            else
            {
                panel[i] = null;
            }
        }
        
    }


    public void OnCallChangeFace()
    {

    }
}
