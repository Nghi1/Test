using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;      
    private Vector3 offset = new Vector3(1f, 10f, -7f); 
    public float followSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        transform.LookAt(target); 
    }
}
