using UnityEngine;

public class MeteorBehavior : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    private Transform player;

    private void Start()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogError("Player not found!");
        }

        Destroy(gameObject, 10f);
    }

    
    private void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;

            transform.position += direction * speed * Time.deltaTime;

            // laat meteor kijken naar speler
            transform.LookAt(player);
        }

        // draai effect
        transform.Rotate(100f * Time.deltaTime, 80f * Time.deltaTime, 50f * Time.deltaTime);
    }

}