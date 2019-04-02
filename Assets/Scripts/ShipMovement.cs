using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;

    Vector3 lookAtVec;
    float lastFire = 3, bulletSpeed = 500;
    int numberOfBullets = 20;
    List<GameObject> bullets;

    private void Start()
    {
        bullets = new List<GameObject>();
        lastFire = Time.time;
        for (int i = 0; i < numberOfBullets; i++)
        {
            GameObject bul = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullets.Add(bul);
            bul.SetActive(false);
        }
    }

    void Update()
    {
        Movement();
        Shoot();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Comet")
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    void Movement()
    {
        lookAtVec = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, transform.localEulerAngles.z);
        lookAtVec.Normalize();
        transform.LookAt(lookAtVec, Vector3.back);
        transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z);
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && Time.time - lastFire > 0.1)
        {
            lastFire = Time.time;
            for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i].activeInHierarchy == false)
                {
                    bullets[i].SetActive(true);
                    bullets[i].transform.position = transform.GetChild(0).transform.position;
                    bullets[i].GetComponent<Rigidbody>().velocity = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y).normalized * bulletSpeed * Time.deltaTime;
                    return;
                }
            }
        }
    }
}