using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class KnobRotation : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Quaternion initialRotation;
    private XRBaseInteractor interactor;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(StartRotation);
        grabInteractable.selectExited.AddListener(EndRotation);
    }

    void StartRotation(SelectEnterEventArgs args)
    {
        interactor = args.interactorObject as XRBaseInteractor;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        if (grabInteractable.isSelected && interactor != null)
        {
            Vector3 handRotation = interactor.transform.eulerAngles;
            transform.rotation = Quaternion.Euler(initialRotation.eulerAngles.x, handRotation.y, initialRotation.eulerAngles.z);
        }
    }

    void EndRotation(SelectExitEventArgs args)
    {
        interactor = null;
    }
}
