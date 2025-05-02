using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    [SerializeField]
    float velocity;
    public float maxVelocity;
    public float accel;
    public float stopDistance;
    public float flyingTime;
    public CharacterController cc;
    float flyCounter;
    float yStart;
    bool flying;
    Transform Player;
    Transform distantObject;
    public Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        flyCounter = 0;
        flying = false;
        yStart = transform.position.y;
        velocity = 0;
        Player = GameObject.Find("Player").transform;
        distantObject = GameObject.Find("DistantObject").transform;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            velocity = -8f;
            flying = true;
            flyCounter = flyingTime;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        velocity = Mathf.Lerp(velocity, maxVelocity, accel * Time.fixedDeltaTime);
        if (!flying)
        {
            this.transform.LookAt(Player);
            myAnimator.SetInteger("State", 1);
        }
        else
        {
            this.transform.LookAt(distantObject);
            myAnimator.SetInteger("State", 2);
        }
        if (Vector3.Distance(this.transform.position, Player.position) > stopDistance)
        {
            cc.Move(Vector3.back * velocity * Time.fixedDeltaTime);
        }
        if (flyCounter > 0)
        {
            flyCounter -= Time.fixedDeltaTime;
        }
        else
        {
            flying = false;
        }
    }
}
