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
        // pause the smoke particles
        particles.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Detect when the up arrow key is pressed down
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // unpause the smoke particles
            particles.SetActive(true);
        }
    }
}
