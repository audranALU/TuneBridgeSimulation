using TMPro;
using UnityEngine;

public class PracticeQuiz : MonoBehaviour
{
    [SerializeField] private BassLessonInteraction bassLesson;
    [SerializeField] private AcademyPlayerController playerMovement;
    [SerializeField] private GameObject quizPanel;
    [SerializeField] private TMP_Text instructionText;

    public bool QuizPassed { get; private set; }

    private bool quizOpen;

    private void Start()
    {
        quizPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        CheckPlayer(other);
    }

    private void OnTriggerStay(Collider other)
    {
        CheckPlayer(other);
    }

    private void CheckPlayer(Collider other)
    {
        AcademyPlayerController player =
            other.GetComponentInParent<AcademyPlayerController>();

        if (player == null || player != playerMovement)
            return;

        if (QuizPassed || quizOpen || !bassLesson.LessonRead)
            return;

        quizOpen = true;
        playerMovement.enabled = false;
        quizPanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void AnswerCorrect()
    {
        QuizPassed = true;
        quizOpen = false;
        quizPanel.SetActive(false);

        playerMovement.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        instructionText.text =
            "Correct! The strings are E, A, D, G.\n" +
            "Next: connect the bass to the amplifier.";
    }

    public void AnswerWrong()
    {
        instructionText.text =
            "Try again. Start with the thickest string: E.";
    }
}