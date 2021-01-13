using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    float vol = 0.5f;
    float volrate = 0.15f;

    public AudioClip[] BGMClips;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            audioSource.Stop();
            int rand = Random.Range(0, BGMClips.Length);
            audioSource.PlayOneShot(BGMClips[rand]);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            vol = vol + (volrate * Time.deltaTime);
            audioSource.volume = vol;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            vol = vol - (volrate * Time.deltaTime);
            audioSource.volume = vol;
        }
    }
}
