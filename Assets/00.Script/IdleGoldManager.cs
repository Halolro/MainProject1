using System.Collections;
using UnityEngine;
using TMPro;

public class IdleGoldManager : MonoBehaviour
{
    [Header("골드 UI 및 설정")]
    public TextMeshProUGUI goldText;
    private int currentGold = 0;
    private bool isGameStarted = false;
    public int bonusGold = 0;

    [Header("물고기 이펙트 설정")]
    public GameObject goldEffect;         // 맵에 띄울 물고기 오브젝트 (현재 Circle)
    public SpriteRenderer effectRenderer; // 물고기 이미지를 바꿔줄 렌더러 컴포넌트
    public Sprite[] fishSprites;          // 랜덤으로 띄울 물고기 이미지들 (5개)

    public float moveDistance = 2f;       // 위로 올라갈 거리 (수치 조절 가능)
    public float moveDuration = 1f;       // 올라가는 데 걸리는 시간 (수치 조절 가능)

    private Vector3 startEffectPos;       // 물고기가 처음에 나타날 시작 위치

    private void Start()
    {
        // 게임 시작 시 이펙트 오브젝트의 초기 위치를 기억해둡니다.
        if (goldEffect != null)
        {
            startEffectPos = goldEffect.transform.position;
        }
    }

    public void OnGameStartButtonClicked()
    {
        if (isGameStarted) return;
        isGameStarted = true;
        StartCoroutine(GoldRoutine());
    }

    private IEnumerator GoldRoutine()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            float waitTime = Random.Range(1f, 5f);
            yield return new WaitForSeconds(waitTime);

            int randomGold = Random.Range(1, 81) + bonusGold;
            currentGold += randomGold;

            UpdateGoldUI();

            // 골드 획득 시 물고기 떠오르는 효과 실행
            StartCoroutine(ShowGoldEffect());
        }
    }

    private void UpdateGoldUI()
    {
        if (goldText != null)
        {
            goldText.text = "Gold: " + currentGold.ToString();
        }
    }

    private IEnumerator ShowGoldEffect()
    {
        // 필요한 변수들이 다 연결되어 있고, 물고기 이미지가 1개 이상 등록되어 있는지 확인
        if (goldEffect != null && fishSprites.Length > 0 && effectRenderer != null)
        {
            // 1. 배열에서 랜덤으로 물고기 이미지 하나 고르기
            int randomIndex = Random.Range(0, fishSprites.Length);
            effectRenderer.sprite = fishSprites[randomIndex];

            // 2. 위치를 원래 시작 위치(바닷속)로 되돌리고 오브젝트 켜기
            goldEffect.transform.position = startEffectPos;
            goldEffect.SetActive(true);

            // 3. 아래에서 위로 부드럽게 올라가는 이동 처리
            float elapsedTime = 0f;
            Vector3 targetPos = startEffectPos + new Vector3(0, moveDistance, 0);

            while (elapsedTime < moveDuration)
            {
                // Lerp를 이용해 시작점과 목표점 사이를 시간에 따라 이동
                goldEffect.transform.position = Vector3.Lerp(startEffectPos, targetPos, elapsedTime / moveDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // 4. 이동이 끝나면 다시 오브젝트 끄기
            goldEffect.SetActive(false);
        }
    }

    public bool TryPurchase(int price)
    {
        if (currentGold >= price)
        {
            currentGold -= price;
            UpdateGoldUI();
            return true;
        }
        return false;
    }

    public void AddBonusGold(int amount)
    {
        bonusGold += amount;
    }
}