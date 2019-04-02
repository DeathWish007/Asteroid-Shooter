using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleGeneration : MonoBehaviour
{
    [SerializeField] GameObject CubePref, CylinderPref, CapsulePref;
    public static List<GameObject> AllAsteroids;
    public static List<SphereCollider> Colls;

    public static int WaveCount = 1;
    public static int ObsCount = 0;
    public static int ScoreVal = 0;

    public Text Score, Wave;

    private void Start()
    {
        AllAsteroids = new List<GameObject>();
        Colls = new List<SphereCollider>();
        Score.text = "Score: 0";
        Wave.text = "Waves: 0";
    }

    void Update()
    {
        if (ObsCount == 0)
            GenerateObs();
        Score.text = "Score: " + ScoreVal.ToString();
        Wave.text = "Waves: " + WaveCount.ToString();
    }

    void GenerateObs()
    {
        for (int i = 0; i < WaveCount; i++)
        {
            GameObject Cube = Instantiate(CubePref, GetRandomStartPoint(), Quaternion.identity);
            GameObject Cylinder = Instantiate(CylinderPref, GetRandomStartPoint(), Quaternion.identity);
            GameObject Capsule = Instantiate(CapsulePref, GetRandomStartPoint(), Quaternion.identity);

            Cube.transform.localEulerAngles = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            Cylinder.transform.localEulerAngles = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            Capsule.transform.localEulerAngles = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));

            AllAsteroids.Add(Cube);
            AllAsteroids.Add(Cylinder);
            AllAsteroids.Add(Capsule);

            Colls.Add(Cube.GetComponent<SphereCollider>());
            Colls.Add(Cylinder.GetComponent<SphereCollider>());
            Colls.Add(Capsule.GetComponent<SphereCollider>());

            Vector3 temp1 = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0);
            Cube.GetComponent<Rigidbody>().velocity = (temp1 - Cube.transform.position).normalized * 100 * Time.deltaTime;
            Vector3 temp2 = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0);
            Cylinder.GetComponent<Rigidbody>().velocity = (temp2 - Cylinder.transform.position).normalized * 150 * Time.deltaTime;
            Vector3 temp3 = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0);
            Capsule.GetComponent<Rigidbody>().velocity = (temp3 - Capsule.transform.position).normalized * 200 * Time.deltaTime;

            ObsCount++;
            ObsCount++;
            ObsCount++;
        }

        AvoidCollision();
    }

    void AvoidCollision()
    {
        for (int j = 0; j < Colls.Count; j++)
        {
            for (int i = 0; i < Colls.Count; i++)
            {
                Physics.IgnoreCollision(Colls[j], Colls[i]);
            }
        }
    }

    Vector3 GetRandomStartPoint()
    {
        Vector3 temp;
        if (Random.value > 0.5f)
        {
            if (Random.value > 0.5f)
                temp = new Vector3(Random.Range(-8.5f, 8.5f), -5.5f);
            else
                temp = new Vector3(Random.Range(-8.5f, 8.5f), 5.5f);
        }
        else
        {
            if (Random.value > 0.5f)
                temp = new Vector3(-8.5f, Random.Range(-5.5f, 5.5f));
            else
                temp = new Vector3(8.5f, Random.Range(-5.5f, 5.5f));
        }

        return temp;
    }
}
