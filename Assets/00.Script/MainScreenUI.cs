using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MenuCameraController : MonoBehaviour
{
    [Header("카메라 설정")]
    public float duration = 1.5f;

    [Header("태양 설정")]
    public Transform sunTransform;

    [Header("UI 설정")]
    public Button startButton;
    public Button quitButton;
    public Button soundButton;
    public GameObject soundPanel;
    public GameObject GameName;
    public GameObject shopMenu;

    private Vector3 targetPosition;
    private bool isMoving = false;

    private void Start()
    {
        soundPanel.SetActive(false);
        shopMenu.SetActive(false);
    }

    public void StartCameraMove()
    {
        if (isMoving) return;

        if (startButton != null) startButton.gameObject.SetActive(false);
        if (quitButton != null) quitButton.gameObject.SetActive(false);
        if (soundButton != null) soundButton.gameObject.SetActive(false);
        if (soundPanel != null) soundPanel.SetActive(false);
        if (GameName != null) GameName.SetActive(false);
        shopMenu.SetActive(true);

        targetPosition = new Vector3(0f, transform.position.y, transform.position.z);
        StartCoroutine(MoveCameraRoutine());
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void ToggleSoundPanel()
    {
        if (soundPanel != null)
        {
            bool isActive = soundPanel.activeSelf;
            soundPanel.SetActive(!isActive);
        }
    }

    private IEnumerator MoveCameraRoutine()
    {
        isMoving = true;
        Vector3 startPosition = transform.position;
        Vector3 startSunPosition = sunTransform != null ? sunTransform.position : Vector3.zero;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            t = Mathf.SmoothStep(0f, 1f, t);

            Vector3 currentCamPos = Vector3.Lerp(startPosition, targetPosition, t);
            float deltaX = currentCamPos.x - startPosition.x;

            transform.position = currentCamPos;

            if (sunTransform != null)
            {
                sunTransform.position = new Vector3(startSunPosition.x + deltaX, sunTransform.position.y, sunTransform.position.z);
            }

            yield return null;
        }

        transform.position = targetPosition;

        if (sunTransform != null)
        {
            float totalDeltaX = targetPosition.x - startPosition.x;
            sunTransform.position = new Vector3(startSunPosition.x + totalDeltaX, sunTransform.position.y, sunTransform.position.z);
        }

        isMoving = false;
    }
}