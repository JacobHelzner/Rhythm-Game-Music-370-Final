using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    float moveSpeed;
    public float baseSpeed;
    public float boostSpeed;
    public float waitSpeed;
    float moveSpeedTarget;
    public float moveAcceleration;

    public float baseStrafeSpeed;
    float strafeSpeed;
    float strafeSpeedTarget;
    public float strafeAcceleration;
    public float strafeRange;
    float origin;

    public Transform boostTarget;
    public Transform baseTarget;
    public Transform waitTarget;
    public FollowTargetY cameraTarget;

    public Gun[] myGuns;

    public Event deathEvent;

    GameManager gameManager;

    LevelManager levelManager;

    bool locked;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        levelManager = gameManager.levelManager;
        locked = false;
        origin = transform.position.x;
        moveSpeed = 0;
        strafeSpeed = 0;
        strafeSpeedTarget = 0;
        moveSpeedTarget = baseSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillPlayer") && !locked)
        {
            deathEvent.Execute();
        }
    }

    public void setLockState(bool state)
    {
        locked = state;
    }

    void getInput()
    {
        if ((Input.GetAxisRaw("Vertical") != 0) || (Input.GetAxisRaw("Horizontal") != 0))
        {
            if (locked)
            {
                moveSpeedTarget = 0;
                cameraTarget.target = baseTarget;
            }
            else
            {
                if (Input.GetAxisRaw("Vertical") != 0)
                {
                    if (Input.GetAxisRaw("Vertical") == 1)
                    {
                        moveSpeedTarget = boostSpeed;
                        cameraTarget.target = boostTarget;
                    }
                    else
                    {
                        moveSpeedTarget = waitSpeed;
                        cameraTarget.target = waitTarget;
                    }
                }
                else
                {
                    moveSpeedTarget = baseSpeed;
                    cameraTarget.target = baseTarget;
                }
            }

            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                if (Input.GetAxisRaw("Horizontal") == 1)
                {
                    strafeSpeedTarget = baseStrafeSpeed * -1;
                }
                else
                {
                    strafeSpeedTarget = baseStrafeSpeed;
                }
            }
            else
            {
                strafeSpeedTarget = 0;
            }
        }
        else
        {
            if (locked)
            {
                moveSpeedTarget = 0;
            }
            else
            {
                moveSpeedTarget = baseSpeed;
            }
            strafeSpeedTarget = 0;
            cameraTarget.target = baseTarget;
        }
    }

    void shootInput()
    {
        if (!locked && Input.GetButton("Jump"))
        {
            foreach (Gun gun in myGuns)
            {
                gun.Trigger();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!levelManager.paused)
        {
            getInput();
            shootInput();
            moveSpeed = Mathf.Lerp(moveSpeed, moveSpeedTarget, moveAcceleration * Time.deltaTime);
            strafeSpeed = Mathf.Lerp(strafeSpeed, strafeSpeedTarget, strafeAcceleration * Time.deltaTime);
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            if (Mathf.Abs(origin - transform.position.x) < strafeRange)
            {
                transform.Translate(Vector3.left * strafeSpeed * Time.deltaTime);
            }
            else
            {
                if ((transform.position.x - origin) < 0)
                {
                    if (strafeSpeed < 0)
                    {
                        transform.Translate(Vector3.left * strafeSpeed * Time.deltaTime);
                    }
                    else
                    {
                        strafeSpeed = 0;
                        transform.position = new Vector3(origin - strafeRange, transform.position.y, transform.position.z);
                    }
                }
                else
                {
                    if (strafeSpeed > 0)
                    {
                        transform.Translate(Vector3.left * strafeSpeed * Time.deltaTime);
                    }
                    else
                    {
                        strafeSpeed = 0;
                        transform.position = new Vector3(origin + strafeRange, transform.position.y, transform.position.z);
                    }
                }
            }
        }
    }
}
