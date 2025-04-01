public class AdaptiveFootsteps : MonoBehaviour {
    public AudioSource footstepSource;
    public AudioClip grassStep;
    public AudioClip metalStep;
    public float stepDistance = 2.0f;

    private Vector3 lastStepPos;

    void Update() {
        if (Vector3.Distance(transform.position, lastStepPos) >= stepDistance) {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit)) {
                switch(hit.collider.tag) {
                    case "Grass":
                        footstepSource.clip = grassStep;
                        break;
                    case "Metal":
                        footstepSource.clip = metalStep;
                        break;
                }
                footstepSource.Play();
                lastStepPos = transform.position;
            }
        }
    }
}
