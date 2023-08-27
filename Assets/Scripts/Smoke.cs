using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    [SerializeField] // Assign particles game object in inspector to control it
    private GameObject particles;

    // Start is called before the first frame update
    void Start()
    {
        particles.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Detect when the up arrow key is pressed down
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            particles.SetActive(true);
        }
            

        //Detect when the up arrow key has been released
        

    }
}
