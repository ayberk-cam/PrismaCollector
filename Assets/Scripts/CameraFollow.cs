using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform character;
    [SerializeField] private float lerpValue;
    [SerializeField] private Vector3 offset;
    
    private void FixedUpdate()
    {
        var desiredPosition = character.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, lerpValue);
    }
}
