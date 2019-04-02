using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Comet")
        {
            Destroy(collision.gameObject);
            gameObject.SetActive(false);
            ObstacleGeneration.ScoreVal++;
            ObstacleGeneration.ObsCount--;
            if (ObstacleGeneration.ObsCount == 0)
                ObstacleGeneration.WaveCount++;
            for (int i = 0; i < ObstacleGeneration.AllAsteroids.Count; i++)
            {
                if (ObstacleGeneration.AllAsteroids[i] == collision.gameObject)
                {
                    ObstacleGeneration.AllAsteroids.Remove(ObstacleGeneration.AllAsteroids[i]);
                    ObstacleGeneration.Colls.Remove(ObstacleGeneration.Colls[i]);
                    return;
                }
            }
        }
    }
}
