using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode leftKey;
    public KeyCode rightKey;

    public KeyCode leftArmKey;
    public Animator leftArm;
    private bool leftArmIsPlayingTemporary = false;
    public KeyCode rightArmKey;
    public Animator rightArm;
    private bool rightArmIsPlayingTemporary = false;

    public LayerMask groundLayer;

    public float armsAnimDuration = 0.5f;
    public float armsAnimAttackSpeed = 0.1f;
    public float armsAnimReleaseSpeed = 0.2f;

    public float raycastDistance = 2f;  // Max distance for raycast
    public float hoverForce = 500f;     // Base upward force
    private Rigidbody rb;

    public float moveSpeed = 5f; // Movement speed

    public DrumStick redStick;
    public DrumStick blueStick;

    void Start()
    {
        // Get the Animator component attached to the object
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

    }

    void Animate()
    {

        // Check for arrow key inputs and trigger corresponding animations
        if (Input.GetKey(upKey))
        {
            if (!Input.GetKey(leftKey) && !Input.GetKey(rightKey))
            {
                animator.CrossFade("MoveForward", 0.1f);
            }
            else
            {
                if (Input.GetKey(rightKey))
                {
                    animator.CrossFade("MoveFR", 0.1f);
                }
                else
                {
                    animator.CrossFade("MoveFL", 0.1f);
                }
            }
        }
        else if (Input.GetKey(downKey))
        {
            if (!Input.GetKey(leftKey) && !Input.GetKey(rightKey))
            {
                animator.CrossFade("MoveBackward", 0.1f);
            }
            else
            {
                if (Input.GetKey(rightKey))
                {
                    animator.CrossFade("MoveBR", 0.1f);
                }
                else
                {
                    animator.CrossFade("MoveBL", 0.1f);
                }
            }
        }
        else if (Input.GetKey(leftKey))
        {
            animator.CrossFade("MoveLeft", 0.1f);
        }
        else if (Input.GetKey(rightKey))
        {
            animator.CrossFade("MoveRight", 0.1f);
        }
        else
        {
            // Play idle animation when no keys are pressed
            animator.CrossFade("Idle", 0.1f);
        }
    }

    private IEnumerator PlayLeftArmAnimation()
    {
        leftArmIsPlayingTemporary = true;
        leftArm.CrossFade("armSwing", armsAnimAttackSpeed);

        yield return new WaitForSeconds(armsAnimDuration); // Wait for animation duration

        leftArm.CrossFade("armIdle", armsAnimReleaseSpeed);
        leftArmIsPlayingTemporary = false;
    }

    private IEnumerator PlayRightArmAnimation()
    {
        rightArmIsPlayingTemporary = true;
        rightArm.CrossFade("armSwing", armsAnimAttackSpeed);

        yield return new WaitForSeconds(armsAnimDuration); // Wait for animation duration

        rightArm.CrossFade("armIdle", armsAnimReleaseSpeed);
        rightArmIsPlayingTemporary = false;
    }

    void ArmMovement()
    {
        if (Input.GetKeyDown(leftArmKey) && !leftArmIsPlayingTemporary)
        {
            StartCoroutine(PlayLeftArmAnimation());
        }
        if (Input.GetKeyDown(rightArmKey) && !rightArmIsPlayingTemporary)
        {
            StartCoroutine(PlayRightArmAnimation());
        }
    }

    void HoverPhysics()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance, groundLayer))
        {
            float distance = hit.distance;  // Distance from origin to collision point
            float forceMultiplier = Mathf.Clamp01(1f - (distance / raycastDistance)); // Scales force as distance decreases
            float appliedForce = hoverForce * forceMultiplier;

            rb.AddForce(Vector3.up * appliedForce, ForceMode.Force); // Apply upward force
        }
    }
    bool CheckCollision(Vector3 targetPosition)
    {
        Collider[] colliders = Physics.OverlapSphere(targetPosition, 0.5f); // Detect collisions around target position
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject != gameObject) // Ignore self
            {
                return true; // Collision detected
            }
        }
        return false; // No collision
    }
    void Movement()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(upKey))
            moveDirection += Vector3.forward; // Move forward
        if (Input.GetKey(downKey))
            moveDirection += Vector3.back; // Move backward
        if (Input.GetKey(leftKey))
            moveDirection += Vector3.left; // Move left
        if (Input.GetKey(rightKey))
            moveDirection += Vector3.right; // Move right

        if (moveDirection != Vector3.zero)
        {
            moveDirection.Normalize(); // Ensures uniform movement speed in all directions

            Vector3 targetPosition = rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime;

            if (!CheckCollision(targetPosition)) // Prevent moving into obstacles
            {
                rb.MovePosition(targetPosition);
            }
        }
    }

    void ResetVelocity()
    {
        // Set X and Z velocity components to zero while keeping Y velocity unchanged
        rb.velocity = new Vector3(0, rb.velocity.y, 0);

        // Set all angular velocity components to zero
        rb.angularVelocity = Vector3.zero;
    }

    void FixedUpdate()
    {
        ResetVelocity();
        HoverPhysics();
        Movement();
    }

    void Update()
    {
        Animate();
        ArmMovement();
    }
}
