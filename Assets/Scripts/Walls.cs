using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
            other.gameObject.SetActive(false);

        if (other.tag == "Comet")
        {
            Destroy(other.gameObject);
            ObstacleGeneration.ObsCount--;
            if (ObstacleGeneration.ObsCount == 0)
                ObstacleGeneration.WaveCount++;
            for (int i = 0; i < ObstacleGeneration.AllAsteroids.Count; i++)
            {
                if (ObstacleGeneration.AllAsteroids[i] == other.gameObject)
                {
                    ObstacleGeneration.AllAsteroids.Remove(ObstacleGeneration.AllAsteroids[i]);
                    ObstacleGeneration.Colls.Remove(ObstacleGeneration.Colls[i]);
                    return;
                }
            }
        }
    }
}