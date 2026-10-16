using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class BassLessonInteraction : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Transform bassStation;
    [SerializeField] private TMP_Text instructionText;
    [SerializeField] private InputActionReference interactAction;
    [SerializeField] private float interactionDistance = 3f;

    public bool LessonRead { get; private set; }

    private void OnEnable()
    {
        if (playerCamera == null || bassStation == null ||
            instructionText == null || interactAction == null)
        {
            Debug.LogError("Assign all BassLessonInteraction references.", this);
            enabled = false;
            return;
        }

        interactAction.action.Enable();
    }

    private void Update()
    {
        if (interactAction.action.WasPressedThisFrame())
        {
            TryInteract();
        }
    }

    public void TryInteract()
    {
        Ray ray = new Ray(
            playerCamera.transform.position,
            playerCamera.transform.forward
        );

        if (!Physics.Raycast(ray, out RaycastHit hit,
            interactionDistance, Physics.DefaultRaycastLayers,
            QueryTriggerInteraction.Ignore))
        {
            return;
        }

        Transform target = hit.collider.transform;

        if (target == bassStation || target.IsChildOf(bassStation))
        {
            LessonRead = true;

            instructionText.text =
                "BASS LESSON\n" +
                "The bass supports the harmony and works with drums " +
                "to create the groove.\n" +
                "A standard four-string bass is tuned E, A, D, G " +
                "from thickest to thinnest string.";
        }
    }

    private void OnDisable()
    {
        if (interactAction != null)
        {
            interactAction.action.Disable();
        }
    }
}