using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torenAI : MonoBehaviour
{
    public float fixedRotation = -90;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(fixedRotation, transform.eulerAngles.y, transform.eulerAngles.z);
        if (target.position.x <= 2 && target.position.z <= 2)
        {
            FaceTarget();
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, transform.rotation.y + 90, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 1);
    }
}
