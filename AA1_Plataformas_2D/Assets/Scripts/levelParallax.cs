using UnityEngine;

public class levelParallax : MonoBehaviour
{
    public Transform character;
    public float parallaxFactor = 0.1f;
    public bool moveOppositeDirection = true; // Toggle for opposite movement

    private Vector3 lastCharacterPosition;
    private Vector3 startBackgroundPosition;

    void Start()
    {
        if (character == null)
        {
            Debug.LogError("Character not assigned to ParallaxEffect script.");
            enabled = false;
            return;
        }

        lastCharacterPosition = character.position;
        startBackgroundPosition = transform.position;
    }

    void LateUpdate()
    {
        Vector3 deltaMovement = character.position - lastCharacterPosition;

        // Reverse movement if 'moveOppositeDirection' is true
        float directionMultiplier = moveOppositeDirection ? -1f : 1f;
        transform.position += new Vector3(
            deltaMovement.x * parallaxFactor * directionMultiplier,
            deltaMovement.y * parallaxFactor * directionMultiplier,
            0
        );

        lastCharacterPosition = character.position;
    }
}

