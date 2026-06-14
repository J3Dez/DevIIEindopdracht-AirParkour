using UnityEngine;

public class FrontRotator : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] private Vector3 rotationSpeed = new Vector3(0, 0, 360); 

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}