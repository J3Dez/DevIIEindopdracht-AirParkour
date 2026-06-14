using UnityEngine;

public class MeteorBehavior : MonoBehaviour
{
    public float fallSpeed = 10f;
    public float forwardSpeed = 3f;
    public float lifeTime = 5f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        Vector3 movement = new Vector3(0, -fallSpeed, -forwardSpeed) * Time.deltaTime;
        transform.Translate(movement, Space.World);

        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
