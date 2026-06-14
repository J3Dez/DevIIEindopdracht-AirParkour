using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 10f;
    [SerializeField] private float horizontalSpeed = 5f;
    [SerializeField] private float verticalSpeed = 5f;
    [SerializeField] private float tiltAmount = 30f;

    //add explotie effect
    public GameObject explosionEffect;

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

   private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Edelsteen"))
        {
            Debug.Log("Edelsteen gevangen  " + other.gameObject.name);

            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.VoegPuntenToe(10);
            }

            Destroy(other.gameObject);
        }
    }

private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Obstacle"))
    {
        GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        explosion.GetComponent<ParticleSystem>().Play();
        Destroy(explosion, 3f);

        Time.timeScale = 0f;
        StartCoroutine(RestartAfterDelay());

        Debug.Log("Gecrasht tegen een obstacle");
    }
}


    private IEnumerator RestartAfterDelay()
    {
        yield return new WaitForSecondsRealtime(3f);
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }
}