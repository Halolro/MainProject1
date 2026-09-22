using UnityEngine;

public class TripleBackgroundParallax : MonoBehaviour
{
    [Header("카메라 설정")]
    public Transform cam;

    [Header("순환할 배경 이미지 3개 (순서대로 등록)")]
    public Transform[] backgrounds = new Transform[3];

    [Header("패럴렉스 설정 (0~1)")]
    [Range(0f, 1f)]
    public float parallaxEffectMultiplierX;

    [Header("자동 스크롤 속도")]
    public float autoScrollSpeedX = -2f;

    [Header("재배치 기준 X 좌표 및 간격")]
    public float resetTargetX = -30f;
    public float imageWidth = 30f;

    private Vector3 lastCameraPosition;

    void Start()
    {
        if (cam == null) cam = Camera.main.transform;
        lastCameraPosition = cam.position;
    }

    void LateUpdate()
    {
        Vector3 deltaMovement = cam.position - lastCameraPosition;
        float parallaxMoveX = deltaMovement.x * (1 - parallaxEffectMultiplierX);

        float autoMoveX = autoScrollSpeedX * Time.deltaTime;

        float totalMoveX = parallaxMoveX + autoMoveX;

        for (int i = 0; i < backgrounds.Length; i++)
        {
            if (backgrounds[i] == null) continue;

            backgrounds[i].position += new Vector3(totalMoveX, 0, 0);

            if (backgrounds[i].position.x <= resetTargetX)
            {
                ScrollToRightmost(i);
            }
        }

        lastCameraPosition = cam.position;
    }

    void ScrollToRightmost(int currentIndex)
    {
        float rightmostX = resetTargetX;

        for (int i = 0; i < backgrounds.Length; i++)
        {
            if (backgrounds[i] != null && backgrounds[i].position.x > rightmostX)
            {
                rightmostX = backgrounds[i].position.x;
            }
        }

        backgrounds[currentIndex].position = new Vector3(rightmostX + imageWidth, backgrounds[currentIndex].position.y, backgrounds[currentIndex].position.z);
    }
}