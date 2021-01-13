using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private int jumpHeight = 8;
    private int maxJump = 0;
    private int jumpCounter = 0;

    public Text JumpText;
    private Rigidbody PlayerRB;
    private AudioSource audioSource;

    public AudioClip[] AudioClips;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Jumping();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            maxJump = 0;
        }
    }

    private void Jumping()
    {
        //Player Jump
        if (maxJump == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpCounter++;
                JumpText.GetComponent<Text>().text = "Jumps: " + jumpCounter;
                PlayerRB.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                ++maxJump;
                //AudioSource.Play();
                int rand = Random.Range(0, AudioClips.Length);
                audioSource.PlayOneShot(AudioClips[rand]);
            }
        }
    }
}