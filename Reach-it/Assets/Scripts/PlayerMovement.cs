using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource playerAudioSource;
    [SerializeField] float movementSpeed;
    [SerializeField] float jumpPower;
    [SerializeField] AudioClip jumpSound;
    float loadingTime = 1f;
    
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        move();

    }

    void move()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed, 0.0f, 0.0f);
        transform.Translate(0.0f, 0.0f, Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed);
         if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            
            rb.AddForce(Vector3.up * jumpPower);
            playerAudioSource.PlayOneShot(jumpSound);

        }
    }

     void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Floor":
                isGrounded = true;
                break;
            case "Finish":
                isGrounded = true;
                Invoke("LoadNextScene", loadingTime);
                break;
            case "Start game":
                isGrounded = true;
                Invoke("LoadNextScene", loadingTime);
                break;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Floor":
                isGrounded = false;
                break;
            case "Finish":
                isGrounded = false;
                break;
            case "Start game":
                isGrounded = false;
                break;
        }
    }

    void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentScene + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

}
