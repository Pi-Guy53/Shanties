using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float Direction { get; set; } = 0f;
    public float Pitch { get; set; } = 5f * Mathf.Deg2Rad;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");
        float rotationSpeed = 720f * Mathf.Deg2Rad;
        float pitchSpeed = 480f * Mathf.Deg2Rad;
        float distance = 8f;

        if (Input.GetMouseButton(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Direction += horizontal * rotationSpeed * Time.deltaTime;
            Pitch = Mathf.Clamp(Pitch - vertical * pitchSpeed * Time.deltaTime, 4f * Mathf.Deg2Rad, 80f * Mathf.Deg2Rad);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }

        transform.position = new Vector3(
            transform.parent.position.x - distance * Mathf.Cos(Direction) * Mathf.Cos(Pitch),
            transform.parent.position.y + distance * Mathf.Sin(Pitch),
            transform.parent.position.z + distance * Mathf.Sin(Direction) * Mathf.Cos(Pitch)
        );

        transform.LookAt(transform.parent, Vector3.up);
    }
}
