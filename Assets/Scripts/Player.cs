using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool gameOver;

    private AudioSource audioSource;
    [SerializeField] AudioClip pickupSound;

    [SerializeField] ParticleSystem pickupEffect;
    public int keyCount;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Key"))
        {
            audioSource.PlayOneShot(pickupSound);
            pickupEffect.transform.position = transform.position;
            pickupEffect.Play();
            keyCount++;
            Destroy(other.gameObject);
        }
        if (other.transform.CompareTag("Finish"))
        {
            gameOver = true;
            GetComponent<CharacterInputManager>().enabled = false;
            FindObjectOfType<GameOverWindow>().OpenWindow();
            Debug.Log("FINISH!");
        }
    }
}
