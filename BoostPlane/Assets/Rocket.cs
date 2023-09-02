using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
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

            rigibody.AddRelativeForce(Vector3.up);
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

        rigibody.freezeRotation = true;
        if (Input.GetKey(KeyCode.L)) { }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward);
        }
        rigibody.freezeRotation = false;
    }





}
