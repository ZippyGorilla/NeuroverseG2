using UnityEngine;

public class DarknessOverlayGradient : MonoBehaviour
{
    [Tooltip("Area defining the center of the effect")]
    public Collider Area;

    [Tooltip("Player or camera to track")]
    public GameObject Player;

    [Tooltip("Renderer with transparent black material")]
    public Renderer OverlayRenderer;

    [Tooltip("Maximum darkness inside the zone (0 = no effect, 1 = full black)")]
    [Range(0, 1)]
    public float ZoneDarkness = 2f;

    [Tooltip("Radius where the darkness fully fades out")]
    public float FadeRadius = 5f;

    private Material _overlayMaterial;

    void Start()
    {
        if (OverlayRenderer != null)
        {
            // Use a unique material instance to avoid modifying shared material
            _overlayMaterial = OverlayRenderer.material;
        }
    }

    void Update()
    {
        if (Player == null || Area == null || _overlayMaterial == null) return;

        // Get the closest point on the zone to the player
        Vector3 closestPoint = Area.ClosestPoint(Player.transform.position);
        float distance = Vector3.Distance(Player.transform.position, closestPoint);

        // Calculate fade factor
        float fade = Mathf.Clamp01(distance / FadeRadius);
        float targetAlpha = ZoneDarkness * (1f - fade);

        // Update overlay material alpha
        Color color = _overlayMaterial.color;
        color.a = targetAlpha;
        _overlayMaterial.color = color;
    }
}
