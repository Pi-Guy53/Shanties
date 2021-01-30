using UnityEngine;

public class ShipControl : MonoBehaviour {
    private Vector3 previousPosition;

    void Awake() {
        previousPosition = transform.position;
    }

    void Update() {
        Vector2 input = new Vector2(-Input.GetAxis("Horizontal"), Mathf.Max(0f, Input.GetAxis("Vertical")));    // not allowed to throw the ship in reverse
        CameraControl cameraData = Camera.main.GetComponent<CameraControl>();
        float inputDirection = Mathf.Atan2(input.y, input.x);
        float inputDistance = input.magnitude;
        float movementDirection = -(cameraData.Direction + inputDirection - Mathf.PI / 2f);

        if (inputDistance > 0f)
        {
            float moveSpeed = 4f;
            Vector3 position = new Vector3(moveSpeed * Mathf.Cos(movementDirection), 0f, moveSpeed * Mathf.Sin(movementDirection));

            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity += position * Time.deltaTime;
            rb.velocity = rb.velocity.normalized * Mathf.Min(rb.velocity.magnitude, 10f);
        }

        Vector3 moved = transform.position - previousPosition;
        if (moved.magnitude > 0.01f) {
            Transform body = GetComponentInChildren<ShipBody>().transform;
            body.rotation = Quaternion.Euler(0f, -Mathf.Atan2(moved.z, moved.x) * Mathf.Rad2Deg, 0f);
            previousPosition = transform.position;
        }
    }
}
