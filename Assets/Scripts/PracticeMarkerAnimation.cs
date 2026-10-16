using UnityEngine;

public class PracticeMarkerAnimation : MonoBehaviour
{
    [SerializeField] private float pulseSpeed = 2f;
    [SerializeField] private float pulseAmount = 0.08f;

    private Vector3 originalScale;

    private void Awake()
    {
        originalScale = transform.localScale;
    }

    private void Update()
    {
        float pulse = 1f + Mathf.Sin(Time.time * pulseSpeed) * pulseAmount;

        transform.localScale = new Vector3(
            originalScale.x * pulse,
            originalScale.y,
            originalScale.z * pulse
        );
    }

    private void OnDisable()
    {
        transform.localScale = originalScale;
    }
}