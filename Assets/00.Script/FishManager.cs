using System.Collections.Generic;
using UnityEngine;

public class FishManager : MonoBehaviour
{
    public static FishManager instance; // 싱글톤

    private List<FishingType> fishList = new List<FishingType>();   // 물고기 리스트

    protected float FishCache = 0f;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        CreateFishList();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    private void CreateFishList()   // 물고기 종류 리스트에 생성
    {
        fishList.Add(new Goby());
        fishList.Add(new SandSmelt());
        fishList.Add(new Halfbeak());
        fishList.Add(new JackMackerel());
        fishList.Add(new Mackerel());
        fishList.Add(new Filefish());
        fishList.Add(new Rockfish());
        fishList.Add(new Flounder());
        fishList.Add(new Bass());
        fishList.Add(new RedSnapper());
        fishList.Add(new Opaleye());
        fishList.Add(new BlackPorgy());
        fishList.Add(new RockBream());
        fishList.Add(new EpinephelusAkaara());
        fishList.Add(new NiphonSpinosus());
    }

    private GrandType GetRandomGrand(FishingRodData rodData)    // 낚시대에 등급에 따른 물고기 등급 결정
    {
        float totalWeight = 0f;

        foreach (GrandType grand in System.Enum.GetValues(typeof(GrandType)))
        {
            totalWeight += rodData.GetWeight(grand);
        }

        float randomValue = Random.Range(0f, totalWeight);

        float currentWeight = 0f;

        foreach (GrandType grand in System.Enum.GetValues(typeof(GrandType)))
        {
            currentWeight += rodData.GetWeight(grand);

            if (randomValue <= currentWeight)
            {
                return grand;
            }
        }

        return GrandType.Bronze;
    }
    private FishingType GetRandomFishByGrand(GrandType grand)   // 물고기 등급에 따른 물고기 종류 결정
    {
        List<FishingType> targetFish = new List<FishingType>();

        foreach (FishingType fish in fishList)
        {
            if (fish.Grand == grand)
            {
                targetFish.Add(fish);
            }
        }

        if (targetFish.Count == 0)
        {
            return null;
        }

        float totalProbability = 0f;

        foreach (FishingType fish in targetFish)
        {
            totalProbability += fish.Probability;
        }

        float randomValue = Random.Range(0f, totalProbability);

        float currentProbability = 0f;

        foreach (FishingType fish in targetFish)
        {
            currentProbability += fish.Probability;

            if (randomValue <= currentProbability)
            {
                return fish;
            }
        }

        return targetFish[targetFish.Count - 1];
    }
    public FishingType FishingSuccess(FishingRodData rodData)
    {
        // 낚시대로 등급 결정
        GrandType randomGrand = GetRandomGrand(rodData);

        // 해당 등급 안에서 물고기 결정
        FishingType fish = GetRandomFishByGrand(randomGrand);

        // 나중에 Ui에 연결할 글
        Debug.Log($"{fish.Name}을(를) 낚았습니다!");
        Debug.Log($"물고기 정보 : {fish.Description}");
        Debug.Log($"물고기 잡힐 확률 : {fish.Probability}");

        return fish;
        
    }

    public void FishCacheSpeedUp(float num) //  물고기 낚는 속도 올리는 함수
    {
        FishCache = num;
    }

    
}

