using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour {


    public float speed;

    private float t = 0;
    private Vector3 p0;
    private Vector3 p1;
    private Vector3 p2;
    private Vector3 p3;
    private Vector3 position;
    private Rigidbody rb;

    private Ray rayUp;
    private RaycastHit rayUpHit;
    private float rayUpHitDistance;

    private Ray rayDown;
    private RaycastHit rayDownHit;
    private float rayDownHitDistance;

    private Ray rayLeft;
    private RaycastHit rayLeftHit;
    private float rayLeftHitDistance;

    private Ray rayRight;
    private RaycastHit rayRightHit;
    private float rayRightHitDistance;

    private Ray rayFordward;
    private RaycastHit rayFordwardHit;
    private float rayFordwardHitDistance;

    private Ray rayBehind;
    private RaycastHit rayBehindHit;
    private float rayBehindHitDistance;



    void Start () {
        p0 = p1 = p2 = p3 = transform.position;
        p1 = RandomizePoint(p1);
        p2 = RandomizePoint(p2);
        p3 = RandomizePoint(p3);
        rb = GetComponent<Rigidbody>();
    }
	
	void Update () {
        if (t > 1)        
            ResetPoints(p3);

        CalculatePosition(t);
        t += Time.deltaTime * speed;

        rb.MovePosition(position);
    }

    private void CalculatePosition(float t)
    {       
        position = ((1 - t) * (1 - t) * (1 - t)) * p0 + 3 * ((1 - t) * (1 - t)) * t * p1 + 3 * (1 - t) * (t * t) * p2 + (t * t * t) * p3;
    }

    private void CalculateRays()
    {
        rayUp = new Ray(transform.position, Vector3.up);
        if (Physics.Raycast(rayUp, out rayUpHit))        
            rayUpHitDistance = rayUpHit.distance;        
        else        
            rayUpHitDistance = 0;
        
        rayDown = new Ray(transform.position, -Vector3.up);
        if (Physics.Raycast(rayDown, out rayDownHit))
            rayDownHitDistance = rayDownHit.distance;
        else
            rayDownHitDistance = 0;

        rayLeft = new Ray(transform.position, -Vector3.right);
        if (Physics.Raycast(rayLeft, out rayLeftHit))
            rayLeftHitDistance = rayLeftHit.distance;
        else
            rayLeftHitDistance = 0;

        rayRight = new Ray(transform.position, Vector3.right);
        if (Physics.Raycast(rayRight, out rayRightHit))
            rayRightHitDistance = rayRightHit.distance;
        else
            rayRightHitDistance = 0;

        rayFordward = new Ray(transform.position, Vector3.forward);
        if (Physics.Raycast(rayFordward, out rayFordwardHit))
            rayFordwardHitDistance = rayFordwardHit.distance;
        else
            rayFordwardHitDistance = 0;

        rayBehind = new Ray(transform.position, -Vector3.forward);
        if (Physics.Raycast(rayBehind, out rayBehindHit))
            rayBehindHitDistance = rayBehindHit.distance;
        else
            rayBehindHitDistance = 0;
    }

    private Vector3 RandomizePoint(Vector3 p)
    {
        CalculateRays();
        p = new Vector3(Random.Range(transform.position.x - (rayLeftHitDistance - transform.lossyScale.x), transform.position.x + (rayRightHitDistance - transform.lossyScale.x)), Random.Range(transform.position.y - (rayDownHitDistance - transform.lossyScale.y), transform.position.y + (rayUpHitDistance - transform.lossyScale.y)), Random.Range(transform.position.z - (rayBehindHitDistance - transform.lossyScale.z), transform.position.z + (rayFordwardHitDistance - transform.lossyScale.z)));
        return p;
    }

    private void ResetPoints(Vector3 startPoint)
    {
        t = 0;
        p0 = startPoint;
        p1 = RandomizePoint(p1);
        p2 = RandomizePoint(p2);
        p3 = RandomizePoint(p3);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Room")
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            ResetPoints(transform.position);
        }
    }
}
