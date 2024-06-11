using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObstacleHapticFeedback : MonoBehaviour
{
    public XRBaseController leftController;
    public XRBaseController rightController;
    public AudioClip collisionSound;
    private AudioSource audioSource;

    void Start()
    {
        if (leftController == null || rightController == null)
        {
            Debug.LogError("Controllers are not assigned.");
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit the obstacle!");
            audioSource.PlayOneShot(collisionSound);

            if (leftController != null)
            {
                leftController.SendHapticImpulse(0.5f, 0.1f);
            }

            if (rightController != null)
            {
                rightController.SendHapticImpulse(0.5f, 0.1f);
            }
        }
    }
}
