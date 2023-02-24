using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // Assign the prefab you want to spawn in the Inspector
    public int numberOfObjectsToSpawn = 10;
    public float minDistanceBetweenObjects = 2f;

    private List<Vector3> previousPositions = new List<Vector3>();
    private Vector3[] spawnPositions = new Vector3[] {
    new Vector3(-1.0f, 0.0f, -1.0f),
    new Vector3(-1.0f, 0.0f, 0.0f),
    new Vector3(-1.0f, 0.0f, 1.0f),
    new Vector3(0.0f, 0.0f, -1.0f),
    new Vector3(0.0f, 0.0f, 0.0f),
    new Vector3(0.0f, 0.0f, 1.0f),
    new Vector3(1.0f, 0.0f, -1.0f),
    new Vector3(1.0f, 0.0f, 0.0f),
    new Vector3(1.0f, 0.0f, 1.0f),
};

    void Start()
    {
        // Shuffle the spawn positions array to randomize the order
        Shuffle(spawnPositions);

        // Spawn objects on the 3x3 plane
        int index = 0;
        while (index < numberOfObjectsToSpawn && index < spawnPositions.Length)
        {
            Vector3 randomPosition = spawnPositions[index];
            bool isTooClose = false;

            // Check if the new position is too close to the previously spawned objects
            foreach (Vector3 previousPosition in previousPositions)
            {
                if (Vector3.Distance(randomPosition, previousPosition) < minDistanceBetweenObjects)
                {
                    isTooClose = true;
                    break;
                }
            }

            // If the new position is not too close, spawn the object
            if (!isTooClose)
            {
                Quaternion randomRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
                GameObject spawnedObject = Instantiate(objectToSpawn, randomPosition, randomRotation);
                previousPositions.Add(randomPosition);
                index++;
            }
        }
    }

    // Shuffle the elements of an array
    private void Shuffle<T>(T[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int randomIndex = Random.Range(i, array.Length);
            T temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }
}
