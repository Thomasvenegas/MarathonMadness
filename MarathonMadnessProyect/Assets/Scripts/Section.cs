using UnityEngine;
using System.Collections.Generic;

public class Section : MonoBehaviour
{
    public List<GameObject> obstacles;
    public float speed = 5f;
    public float sectionSize = 30f; // Asegúrate de que coincide con el tamaño real
    private int sectionCount;
    
    void Start()
    {
        sectionCount = GameObject.FindGameObjectsWithTag("Section").Length;
        obstacles = new List<GameObject>();

        foreach (Transform child in transform)
        {
            if (child.CompareTag("Obstacle"))
            {
                obstacles.Add(child.gameObject);
            }
        }

        if (obstacles.Count == 0)
        {
            Debug.LogWarning("No se encontraron obstáculos con la etiqueta 'Obstacle'");
            return;
        }

        EnableRandomObstacle();
    }

    public void EnableRandomObstacle()
    {
        foreach (GameObject obstacle in obstacles)
        {
            obstacle.SetActive(false);
        }

        int randomIndex = Random.Range(0, obstacles.Count);
        obstacles[randomIndex].SetActive(true);
    }

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        if (transform.position.z <= -sectionSize * 1.5f) // Mejor margen
        {
            transform.Translate(Vector3.forward * sectionSize * sectionCount);
            EnableRandomObstacle();
        }
    }
}
