using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public enum ItemType { Rod, Float }

    [Header("상품 설정")]
    public ItemType itemType;
    public int itemPrice;
    public Sprite itemSprite;
    public int bonusAmount = 20;

    [Header("연결 설정")]
    public SpriteRenderer targetRenderer; 
    public IdleGoldManager goldManager;

    private bool isFirstPurchase = true;

    public void OnBuyButtonClicked()
    {
        if (goldManager.TryPurchase(itemPrice))
        {
            if (targetRenderer != null && itemSprite != null)
            {
                targetRenderer.sprite = itemSprite;
            }

            if (isFirstPurchase)
            {
                goldManager.AddBonusGold(bonusAmount);

                if (itemType == ItemType.Rod)
                {
                    goldManager.AddMinGoldOffset(5); 
                    Debug.Log($"낚시대 구매! 보너스 {bonusAmount} 및 최소 획득 금액 5 증가.");
                }
                else if (itemType == ItemType.Float)
                {
                    goldManager.AddTimeReduction(0.5f); 
                    Debug.Log($"찌 구매! 보너스 {bonusAmount} 및 획득 시간 0.5초 감소.");
                }

                isFirstPurchase = false;
            }
            else
            {
                Debug.Log("이미 구매했던 아이템입니다. (이미지만 교체됨)");
            }
        }
        else
        {
            Debug.Log("골드가 부족합니다.");
        }
    }
}