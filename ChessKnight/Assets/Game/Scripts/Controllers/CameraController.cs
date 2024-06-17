using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float rotationSpeed;

    private Transform cameraPivot;
    private float mousePosition;
    private float offset;

    private void Awake()
    {
        cameraPivot = transform.parent;
    }

    private void Update()
    {
        UpdateData();
    }

    private void LateUpdate()
    {
        UpdateCameraRotation();
    }

    private void UpdateData()
    {
        if (Input.GetMouseButtonDown(1))
        {
            offset = 0.0f;
            mousePosition = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(1))
        {
            offset = Input.mousePosition.x - mousePosition;
            mousePosition = Input.mousePosition.x;
        }
    }

    private void UpdateCameraRotation()
    {
        if (Input.GetMouseButton(1))
        {
            cameraPivot.eulerAngles = new Vector3(cameraPivot.eulerAngles.x, cameraPivot.eulerAngles.y + (offset * rotationSpeed * Time.deltaTime), cameraPivot.eulerAngles.z);
        }
    }
}
