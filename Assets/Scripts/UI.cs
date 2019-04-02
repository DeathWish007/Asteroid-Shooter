using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void StartGame()
    {
        ObstacleGeneration.AllAsteroids.Clear();
        ObstacleGeneration.Colls.Clear();
        ObstacleGeneration.ObsCount = ObstacleGeneration.ScoreVal = 0;
        ObstacleGeneration.WaveCount = 1;
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
