using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 10f;
    [SerializeField] private float horizontalSpeed = 5f;
    [SerializeField] private float verticalSpeed = 5f;
    [SerializeField] private float tiltAmount = 30f;

    private void Update()
    {
        MoveForward();
        MoveSideways();
        MoveUpDown();
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }

    private void MoveSideways()
    {
        float input = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * input * horizontalSpeed * Time.deltaTime, Space.World);

        float tilt = -input * tiltAmount;
        transform.rotation = Quaternion.Euler(0f, 0f, tilt);



    }

    
    private void MoveUpDown()
    {
        float input = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * input * verticalSpeed * Time.deltaTime, Space.World);
    }

}