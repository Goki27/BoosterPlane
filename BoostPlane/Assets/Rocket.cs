using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float rcsThrust = 10f;
    [SerializeField] private float mainThrust = 100f;
    Rigidbody rigibody;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip death;
    [SerializeField] AudioClip sucess;
    [SerializeField] ParticleSystem MainEngineParticle;
    [SerializeField] ParticleSystem deathParticle;
    [SerializeField] ParticleSystem sucessParticle;
    AudioSource audio;
    enum State { Alive,dying,tanscending}
    State state= State.Alive;
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
            ApplyThrust();

        }
        else
        {
            audio.Stop();
            MainEngineParticle.Stop();
        }
        
    }

    private void ApplyThrust()
    {
        rigibody.AddRelativeForce(Vector3.up * mainThrust);
        if (!audio.isPlaying)
        {
            audio.PlayOneShot(mainEngine);
        }
        MainEngineParticle.Play();
        print("Thrust rocket is thrusting");
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
        if(state!=State.Alive) { return; }
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                SucessSOund();
                break;
            default:
                DeathSOund();
                break;
        }
    }

    private void DeathSOund()
    {
        state = State.dying;
        audio.Stop();
        audio.PlayOneShot(death);
        deathParticle.Play();
        Invoke("LoadFirstLevel", 1f);
    }

    private void SucessSOund()
    {
        state = State.tanscending;

        audio.Stop();
        audio.PlayOneShot(sucess);
        sucessParticle.Play();
        Invoke("LoadNextLevel", 1f);
    }

    private  void LoadNextLevel()
    {
        SceneManager.LoadScene(1);
    }                                        
    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);
    }
}
