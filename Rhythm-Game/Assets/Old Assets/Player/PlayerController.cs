using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public CharacterController controller;
    public Animator animator;
    public bool walking;
    public bool attacking;
    public float moveSpeed;
    public KeyCode attackButton;
    float attackCounter;
    public float attackDelay;
    public Collider attackSphere;
    // Start is called before the first frame update
    void Start()
    {
        attackCounter = 0f;
        attackSphere.enabled = false;
    }

    void Animation()
    {
        if (attacking)
        {
            animator.SetInteger("State", 2);
        }
        else if (walking) {
            animator.SetInteger("State", 1);
        }
        else
        {
            animator.SetInteger("State", 0);
        }
    }
    void Attack()
    {
        if (attackCounter > 0)
        {
            attackCounter -= Time.deltaTime;
            if (attackCounter < (attackDelay / 1.5))
            {
                attackSphere.enabled = true;
            }
        }
        else
        {
            attackSphere.enabled = false;
            attacking = false;
        }
        if (Input.GetKeyDown(attackButton))
        {
            attacking = true;
            attackCounter = attackDelay;
        }
    }
    void Movement()
    {
        Vector3 moveVector = Vector3.left * -1f * Input.GetAxis("Horizontal") + Vector3.forward * Input.GetAxis("Vertical");
        Quaternion lookVector = Quaternion.LookRotation(moveVector, Vector3.up);
        if (!attacking)
        {
            controller.Move(moveVector * Time.deltaTime * moveSpeed);
        }
        else
        {
            controller.Move(moveVector * Time.deltaTime * 0.05f);
        }
        if (moveVector.magnitude > 0.3f)
        {
            walking = true;
            controller.transform.rotation = lookVector;
        }
        else
        {
            walking = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Attack();
        Animation();
    }
}
