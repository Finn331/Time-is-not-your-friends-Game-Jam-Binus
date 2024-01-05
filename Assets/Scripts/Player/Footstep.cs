using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioClip walkingSound;
    public AudioClip runningSound;
    public LayerMask groundLayer;
    public Transform footTransform;

    private AudioSource audioSource;
    private bool isGrounded;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Ground Check using Raycast2D
        isGrounded = Physics2D.Raycast(footTransform.position, Vector2.down, 0.1f, groundLayer);

        // Check for player input to determine if walking or running
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            PlayFootstepSound(runningSound);
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            PlayFootstepSound(walkingSound);
        }
    }

    private void PlayFootstepSound(AudioClip footstepSound)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = footstepSound;
            audioSource.Play();
        }
    }
}
