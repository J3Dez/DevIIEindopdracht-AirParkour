using UnityEngine;

public class MeteorBehavior : MonoBehaviour
{
    [SerializeField] private float speed = 15f;

    private void Start()
    {
        // vernietig meteor na 10 seconden (cleanup)
        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        // beweeg recht naar achter (richting speler)
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);

        // draai effect voor realisme
        transform.Rotate(100f * Time.deltaTime, 80f * Time.deltaTime, 50f * Time.deltaTime);
    }
}