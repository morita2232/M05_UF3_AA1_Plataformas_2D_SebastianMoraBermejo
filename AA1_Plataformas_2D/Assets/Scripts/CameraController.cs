/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;

    private Vector2 targetPosition;
    private Vector2 currentPosition;

    public float rightMax;
    public float leftMax;
    public float upMax;
    public float downMax;

    public float speed = 5f;

    public Transform center;
    public Transform leftLimit;
    public Transform rightLimit;
    public Transform upLimit;
    public Transform downLimit;

    void Start()
    {
        if (leftLimit == null || rightLimit == null || upLimit == null || downLimit == null)
        {
            Debug.LogError("Limit transforms are not assigned in CameraController.");
            return;
        }

        // Set movement boundaries
        leftMax = leftLimit.position.x;
        rightMax = rightLimit.position.x;
        upMax = upLimit.position.y;
        downMax = downLimit.position.y;

        // Initialize camera position based on target
        if (target != null)
        {
            targetPosition = target.transform.position;
            targetPosition.x = Mathf.Clamp(targetPosition.x, leftMax, rightMax);
            targetPosition.y = Mathf.Clamp(targetPosition.y, downMax, upMax);

            transform.position = new Vector3(targetPosition.x, targetPosition.y, -10); // -10 is standard for 2D camera
        }
        else
        {
            Debug.LogError("No target assigned to CameraController.");
        }
    }

    void LateUpdate()
    {
        MoveCam();
    }

    void MoveCam()
    {
        if (target == null) return;

        // Get player position and clamp it within limits
        targetPosition.x = Mathf.Clamp(target.transform.position.x, leftMax, rightMax);
        targetPosition.y = Mathf.Clamp(target.transform.position.y, downMax, upMax);

        // Smoothly move camera to clamped position
        Vector3 smoothPosition = Vector3.Lerp(transform.position, new Vector3(targetPosition.x, targetPosition.y, -10), speed * Time.unscaledDeltaTime);
        transform.position = smoothPosition;
    }
}
*/

using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Follow Target")]
    public Transform target; // Assign your character's transform in the inspector

    [Header("Smooth Follow Settings")]
    [Tooltip("How quickly the camera catches up to the target (lower values = smoother follow)")]
    [Range(0.1f, 1f)] public float smoothSpeed = 0.125f;

    [Header("Offset Settings")]
    public Vector3 offset = new Vector3(0f, 0f, -10f); // Default offset for 2D (z should be negative)

    [Header("Bounds (Optional)")]
    public bool useBounds = false;
    public Vector2 minBounds;
    public Vector2 maxBounds;

    private void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Camera target is not assigned!");
            return;
        }

        // Calculate desired position
        Vector3 desiredPosition = target.position + offset;

        // Apply smoothing
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Apply bounds if enabled
        if (useBounds)
        {
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, minBounds.x, maxBounds.x),
                Mathf.Clamp(transform.position.y, minBounds.y, maxBounds.y),
                transform.position.z
            );
        }
    }
}