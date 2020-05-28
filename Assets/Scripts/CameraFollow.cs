using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float distance;
    [SerializeField] private float viewYOffset;
    Vector3 referenceDistance;

    private void LateUpdate()
    {
        FollowTarget();
    }

    // Start is called before the first frame update
    void FollowTarget()
    {
        float cameraHeight = target.position.y + Mathf.Sqrt(2 * distance * distance);
        float referenceZ = target.position.z - distance;
        float referenceX = target.position.x - distance;
        referenceDistance = new Vector3(referenceX, cameraHeight + viewYOffset, referenceZ);
        transform.position = referenceDistance;
    }
}
