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
    public int minGoldOffset = 0;
    public float timeReduction = 0f; 

    [Header("물고기 이펙트 설정")]
    public GameObject goldEffect;
    public SpriteRenderer effectRenderer;
    public Sprite[] fishSprites;

    public float moveDistance = 2f;
    public float moveDuration = 1f;

    private Vector3 startEffectPos;

    private void Start()
    {
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
            float minTime = Mathf.Max(0.1f, 1f - timeReduction);
            float maxTime = Mathf.Max(0.1f, 5f - timeReduction);
            float waitTime = Random.Range(minTime, maxTime);

            yield return new WaitForSeconds(waitTime);

            int minGold = Mathf.Min(1 + minGoldOffset, 80);
            int randomGold = Random.Range(minGold, 81) + bonusGold;

            currentGold += randomGold;

            UpdateGoldUI();

            StartCoroutine(ShowGoldEffect());
        }
    }

    private void UpdateGoldUI()
    {
        if (goldText != null)
        {
            goldText.text = "보유한 골드: " + currentGold.ToString();
        }
    }

    private IEnumerator ShowGoldEffect()
    {
        if (goldEffect != null && fishSprites.Length > 0 && effectRenderer != null)
        {
            int randomIndex = Random.Range(0, fishSprites.Length);
            effectRenderer.sprite = fishSprites[randomIndex];

            goldEffect.transform.position = startEffectPos;
            goldEffect.SetActive(true);

            float elapsedTime = 0f;
            Vector3 targetPos = startEffectPos + new Vector3(0, moveDistance, 0);

            while (elapsedTime < moveDuration)
            {
                goldEffect.transform.position = Vector3.Lerp(startEffectPos, targetPos, elapsedTime / moveDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

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

    public void AddMinGoldOffset(int amount)
    {
        minGoldOffset += amount;
    }

    public void AddTimeReduction(float amount)
    {
        timeReduction += amount;
    }
}