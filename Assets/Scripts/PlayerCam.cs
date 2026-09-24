using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public Transform orientation;
    [SerializeField] private float camSensitivityX;
    [SerializeField] private float camSensitivityY;
    private float rotationX;
    private float rotationY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Hide cursor from view
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Get mouse drag
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * camSensitivityX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * camSensitivityY;

        rotationY += mouseX;
        
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        // Pass values into player rotation
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        orientation.rotation = Quaternion.Euler(0, rotationY, 0);
    }
}
