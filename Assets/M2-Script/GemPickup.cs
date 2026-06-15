using UnityEngine;

public class GemPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("GEM GEPAKT!");

            ScoreManager.Instance.VoegPuntenToe(10);

            Destroy(gameObject);
        }
    }
}
