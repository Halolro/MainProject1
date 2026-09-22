using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [Header("상품 설정")]
    public int itemPrice;
    public Sprite itemSprite;
    public int bonusAmount = 20; 

    [Header("연결 설정")]
    public SpriteRenderer playerRod;
    public IdleGoldManager goldManager;

    private bool isFirstPurchase = true;

    public void OnBuyButtonClicked()
    {
        if (goldManager.TryPurchase(itemPrice))
        {
            if (playerRod != null && itemSprite != null)
            {
                playerRod.sprite = itemSprite;
            }

            if (isFirstPurchase)
            {
                goldManager.AddBonusGold(bonusAmount);
                isFirstPurchase = false; 
                Debug.Log($"최초 구매 성공! 획득 골드가 {bonusAmount}만큼 증가했습니다.");
            }
            else
            {
                Debug.Log("이미 구매했던 낚시대입니다. (이미지만 교체됨)");
            }
        }
        else
        {
            Debug.Log("골드가 부족합니다.");
        }
    }
}