using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]

public class Obstacle : MonoBehaviour
{
    
    [SerializeField]Vector3 movementVector;
    [Range(0, 1)][SerializeField] float movementFactorl;
    Vector3 startingPos;
    [SerializeField]float period = 2f;


    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;   
    }

    // Update is called once per frame
    void Update()
    {

        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawSinWa= Mathf.Sin(cycles * tau);
        
        Vector3 offset = movementVector * movementFactorl;
        transform.position = startingPos + offset;
    }
}
