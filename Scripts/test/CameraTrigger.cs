using UnityEngine;

public class CameraTrigger : MonoBehaviour
{ public Transform cameraTransform;
    private Vector3 newCameraPosition = new Vector3(0, 0.5f, 0);
    private Vector3 newCameraRotation = new Vector3(80f, 0f, 0f);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cameraTransform.position = newCameraPosition;
            cameraTransform.eulerAngles = newCameraRotation;
        }
    }
}
