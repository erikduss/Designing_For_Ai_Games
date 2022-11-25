using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEnemy : MonoBehaviour
{
    private float speed = 1;
    private float minimumTurningDegree = 15f;
    [SerializeField] private Transform playerTransform;
    private Animator anim;
    private Rigidbody rb;


    [SerializeField] bool rotate = false;

    Vector3 turningVelocity;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        turningVelocity = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //RotateToPlayer();
        //if(rotate) Rotate();

        Debug.Log(Angle());
    }

    private float Angle()
    {
        Vector3 localTarget = transform.InverseTransformPoint(playerTransform.position);

        float angle = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;

        return angle;
    }

    private void Rotate()
    {
        Vector3 targetDir = playerTransform.position - transform.position;
        Vector3 forward = transform.forward;
        Vector3 localTarget = transform.InverseTransformPoint(playerTransform.position);

        float angle = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;

        turningVelocity.y = angle;

        if (Mathf.Abs(angle) > minimumTurningDegree)
        {
            //rotating to the right = bigger
            if (angle > 0)
            {
                anim.SetBool("Rotating", true);
                anim.SetFloat("RotationSpeed", 1);
                Quaternion deltaRotation = Quaternion.Euler(turningVelocity * Time.deltaTime*2);
                rb.MoveRotation(rb.rotation * deltaRotation);
            }
            else if (angle < 0)
            {
                anim.SetBool("Rotating", true);
                anim.SetFloat("RotationSpeed", -1);
                Quaternion deltaRotation = Quaternion.Euler(turningVelocity * Time.deltaTime*2);
                rb.MoveRotation(rb.rotation * deltaRotation);
            }
            else
            {
                anim.SetBool("Rotating", false);
                anim.SetFloat("RotationSpeed", 0);
            }
        }
        else
        {
            anim.SetBool("Rotating", false);
            anim.SetFloat("RotationSpeed", 0);
        }
    }

    private void RotateToPlayer()
    {
        Vector3 relativePos = playerTransform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
         
        Quaternion current = transform.localRotation;

        rotation.x = current.x;
        rotation.z = current.z;

        Debug.Log(rotation.y);

        if (Mathf.Abs(current.y - rotation.y) > minimumTurningDegree)
        {
            transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime * speed);

            //rotating to the right = bigger
            if (rotation.y > transform.localRotation.y)
            {
                anim.SetBool("Rotating", true);
                anim.SetFloat("RotationSpeed", 1);
            }
            else if (rotation.y < transform.localRotation.y)
            {
                anim.SetBool("Rotating", true);
                anim.SetFloat("RotationSpeed", -1);
            }
            else
            {
                anim.SetBool("Rotating", false);
                anim.SetFloat("RotationSpeed", 0);
            }
        }
        else
        {
            anim.SetBool("Rotating", false);
            anim.SetFloat("RotationSpeed", 0);
        }
    }
}
