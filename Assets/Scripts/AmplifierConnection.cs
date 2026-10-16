using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class AmplifierConnection : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Transform amplifier;
    [SerializeField] private Collider bassCollider;
    [SerializeField] private Collider amplifierCollider;
    [SerializeField] private PracticeQuiz practiceQuiz;
    [SerializeField] private LineRenderer cable;
    [SerializeField] private TMP_Text instructionText;
    [SerializeField] private InputActionReference interactAction;

    [Header("Audio")]
    [SerializeField] private AudioSource amplifierAudio;

    private bool connected;

    private void Start()
    {
        cable.useWorldSpace = true;
        cable.positionCount = 3;
        cable.startWidth = 0.025f;
        cable.endWidth = 0.025f;
        cable.enabled = false;
    }

    private void OnEnable()
    {
        if (interactAction != null)
        {
            interactAction.action.Enable();
        }
    }

    private void Update()
    {
        if (interactAction != null &&
            interactAction.action.WasPressedThisFrame())
        {
            TryConnect();
        }
    }

    public void TryConnect()
    {
        if (connected)
            return;

        Ray ray = new Ray(
            playerCamera.transform.position,
            playerCamera.transform.forward
        );

        if (!Physics.Raycast(
            ray,
            out RaycastHit hit,
            3f,
            Physics.DefaultRaycastLayers,
            QueryTriggerInteraction.Ignore))
        {
            return;
        }

        Transform target = hit.collider.transform;

        if (target != amplifier && !target.IsChildOf(amplifier))
            return;

        if (!practiceQuiz.QuizPassed)
        {
            instructionText.text =
                "Complete the bass lesson and practice quiz first.";
            return;
        }

        Vector3 start = bassCollider.bounds.center;
        Vector3 end = amplifierCollider.bounds.center;

        Vector3 middle = (start + end) * 0.5f;
        middle.y = Mathf.Min(
            bassCollider.bounds.min.y,
            amplifierCollider.bounds.min.y
        ) + 0.03f;

        cable.SetPosition(0, start);
        cable.SetPosition(1, middle);
        cable.SetPosition(2, end);
        cable.enabled = true;

        connected = true;

        if (amplifierAudio != null)
        {
            amplifierAudio.Play();
        }

        instructionText.text =
            "LESSON COMPLETE!\n" +
            "You learned the bass's role, identified its strings, " +
            "and connected it to an amplifier.\n" +
            "TuneBridge supports learning opportunities for instrumentalists.";
    }

    private void OnDisable()
    {
        if (interactAction != null)
        {
            interactAction.action.Disable();
        }
    }
}