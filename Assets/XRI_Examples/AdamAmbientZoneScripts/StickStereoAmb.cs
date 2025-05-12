using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class StickyStereoAmbience : MonoBehaviour
{
    [Tooltip("Ambience zone")]
    public Collider Area;

    [Tooltip("Player or camera to track")]
    public Transform Player;

    [Tooltip("Volume while inside the zone")]
    [Range(0f, 1f)]
    public float VolumeInside = 1f;

    [Tooltip("Minimum volume after full fade-out")]
    [Range(0f, 1f)]
    public float VolumeOutside = 0.0f;

    [Tooltip("Distance over which the volume fades")]
    public float FadeDistance = 15f;

    private Transform originalParent;
    private AudioSource audioSource;
    private bool isFollowing = false;

    void Start()
    {
        originalParent = transform.parent;
        audioSource = GetComponent<AudioSource>();
        audioSource.spatialBlend = 0f; // 2D stereo

        if (IsInsideZone())
        {
            AttachToPlayer();
        }
        else
        {
            DetachAndFreeze();
        }
    }

    void Update()
    {
        if (Area == null || Player == null) return;

        bool inside = IsInsideZone();

        if (inside && !isFollowing)
        {
            AttachToPlayer();
        }
        else if (!inside && isFollowing)
        {
            DetachAndFreeze();
        }

        UpdateVolume();
    }

    bool IsInsideZone()
    {
        return Area.ClosestPoint(Player.position) == Player.position;
    }

    void AttachToPlayer()
    {
        transform.SetParent(Player);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        isFollowing = true;
    }

    void DetachAndFreeze()
    {
        transform.SetParent(originalParent);
        transform.position = Area.ClosestPoint(Player.position);
        isFollowing = false;
    }

    void UpdateVolume()
    {
        Vector3 closest = Area.ClosestPoint(Player.position);
        float distance = Vector3.Distance(Player.position, closest);

        float t = Mathf.Clamp01(distance / FadeDistance); // 0 = at edge, 1 = fully faded
        float volume = Mathf.Lerp(VolumeInside, VolumeOutside, t);
        audioSource.volume = volume;
    }
}