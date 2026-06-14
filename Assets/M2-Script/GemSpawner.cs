using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    public GameObject gemPrefab;
    public Transform vliegtuig;
    
    public float interval = 1f;     // Om de hoeveel seconden spawnen?
    public float maxGems = 15;      
    public float afstandVoorUit = 30f; //  spawnen van edelstenen

    private List<GameObject> gems = new List<GameObject>();

    void Start()
    {
        // Start de timer die blijft spawnen
        InvokeRepeating(nameof(Spawn), 0f, interval);
    }

    void Update()
    {
        //  de lijst opruimen
        for (int i = gems.Count - 1; i >= 0; i--)
        {
            if (!gems[i]) gems.RemoveAt(i);
        }
    }

    void Spawn()
    {
        if (gems.Count >= maxGems || !vliegtuig) return;

        // spawnen voor de neus van het vliegtuig
        Vector3 rechtVoorUit = vliegtuig.position + (vliegtuig.forward * afstandVoorUit);

        Vector3 randomAfwijking = new Vector3(
            Random.Range(-10f, 10f), // Links of rechts
            Random.Range(-4f, 4f),   // Iets hoger of lager
            Random.Range(-5f, 5f)    // Iets verder of dichterbij
        );

        //  optellen 
        Vector3 spawnPos = rechtVoorUit + randomAfwijking;

        gems.Add(Instantiate(gemPrefab, spawnPos, Quaternion.identity));
    }
}