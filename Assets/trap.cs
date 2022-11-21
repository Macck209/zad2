using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trap : MonoBehaviour
{
    int a;

    private void Start()
    {
        a = 5;
    }

    void Update()
    {
        transform.position += new Vector3(a*Time.deltaTime,0,0);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "wall")
        {
            a *= -1;
        }
    }
}
