using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class bla : MonoBehaviour
{
    private int coins;
    private int beboks;
    private Camera camera;

    private void Start()
    {
        coins = 0;
        beboks = 0;
        camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(camera.transform.position,camera.transform.forward, out hit,150))
            {
                if (hit.collider.tag == "enemy")
                {
                    beboks++;
                    hit.collider.gameObject.SetActive(false);
                }
                if(hit.collider.tag == "coin")
                {
                    coins++;
                    hit.collider.gameObject.SetActive(false);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "trap" ^ collision.collider.tag == "enemy") 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (collision.collider.tag == "finish" && coins>1 && beboks>1)
        {
            Destroy(this.gameObject);
        }
        if (collision.collider.tag == "coin")
        {
            coins++;
            collision.collider.gameObject.SetActive(false);
        }
    }
}
