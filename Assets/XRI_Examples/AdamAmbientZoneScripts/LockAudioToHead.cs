using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LockAudioToHead : MonoBehaviour
{
    void Start()
    {
        // Find main camera (assumes it's tagged correctly)
        Camera mainCam = Camera.main;

        if (mainCam != null)
        {
            // Parent this audio source to the camera
            transform.SetParent(mainCam.transform);

            // Snap position and rotation
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;

            // Optional: Ensure AudioSource is set up for 3D
            AudioSource source = GetComponent<AudioSource>();
            source.spatialBlend = 1f; // fully 3D
            source.spread = 0f;       // no stereo widening
        }
        else
        {
            Debug.LogWarning("No Main Camera found. Make sure your VR camera is tagged as MainCamera.");
        }
    }
}