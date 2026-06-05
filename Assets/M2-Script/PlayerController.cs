using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 10f;
    [SerializeField] private float horizontalSpeed = 5f;

    private void Update()
    {
        MoveForward();
        MoveSideways();
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }

    private void MoveSideways()
    {
        float input = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * input * horizontalSpeed * Time.deltaTime);
    }
}