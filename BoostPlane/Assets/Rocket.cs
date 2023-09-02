using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField]private float rcsThrust = 10f;
    [SerializeField] private float mainThrust = 100f;
    Rigidbody rigibody;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {

        audio = GetComponent<AudioSource>();
        rigibody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        rotate();
        Thrusting();
    }

    private void Thrusting()
    {
        //logic for flight flying and audio touchUp for rocket launch

        if (Input.GetKey(KeyCode.Space))
        {

            rigibody.AddRelativeForce(Vector3.up*mainThrust);
            if (!audio.isPlaying)
            {
                audio.Play();
            }
            print("Thrust rocket is thrusting");


        }
        else
        {
            audio.Stop();
        }
    }

    //logic for movement of the player
    void rotate()
    {

       
        if (Input.GetKey(KeyCode.L)) { }

        rigibody.freezeRotation = true;
        float rotationSpeed = rcsThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
        {
           
            transform.Rotate(Vector3.forward*rotationSpeed);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward*rotationSpeed);
        }
        rigibody.freezeRotation = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("Friendly");
                break;
            case "Fuel":
                print("Fuel");
                break;

        }
    }





}
