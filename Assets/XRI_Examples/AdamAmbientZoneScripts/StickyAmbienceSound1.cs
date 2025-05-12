using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class StickyAmbienceSound : MonoBehaviour
{
    [Tooltip("Zone where the sound follows the player")]
    public Collider Area;

    [Tooltip("Camera or player object to track")]
    public Transform Player;

    private bool isFollowing = false;
    private Transform originalParent;

    void Start()
    {
        originalParent = transform.parent;
    }

    void Update()
    {
        if (Area == null || Player == null) return;

        bool insideZone = Area.bounds.Contains(Player.position);

        if (insideZone && !isFollowing)
        {
            // Player just entered — start following
            transform.SetParent(Player);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            isFollowing = true;
        }
        else if (!insideZone && isFollowing)
        {
            // Player just exited — detach and freeze
            transform.SetParent(originalParent); // or null
            isFollowing = false;
        }
    }
}