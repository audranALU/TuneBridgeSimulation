using TMPro;
using UnityEngine;

public class LessonCompletionSave : MonoBehaviour
{
    [SerializeField] private LineRenderer cable;
    [SerializeField] private TMP_Text savedStatusText;

    private const string SaveKey = "TuneBridgeLessonCompleted";
    private bool savedThisSession;

    private void Start()
    {
        bool completedBefore = PlayerPrefs.GetInt(SaveKey, 0) == 1;

        savedStatusText.text = completedBefore
            ? "Previously completed — you can replay the lesson."
            : "Complete the lesson to save your achievement.";
    }

    private void Update()
    {
        if (savedThisSession || !cable.enabled)
            return;

        PlayerPrefs.SetInt(SaveKey, 1);
        PlayerPrefs.Save();

        savedThisSession = true;
        savedStatusText.text = "Achievement saved: Bass Basics completed!";
    }
}