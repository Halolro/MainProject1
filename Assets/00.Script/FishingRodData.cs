using UnityEngine;

public class FishingRodData
{
    // 낚시대 종류에 따른 등급별 확률 데이터 반환
    public float Bronze { get; }
    public float Sliver { get; }
    public float Gold { get; }
    public float Platinum { get; }
    public float Emerald { get; }
    public float Diamond { get; }
    public float Master { get; }
    public float GrandMaster { get; }

    public FishingRodData(
        float bronze,
        float sliver,
        float gold,
        float platinum,
        float emerald,
        float diamond,
        float master,
        float grandMaster)
    {
        Bronze = bronze;
        Sliver = sliver;
        Gold = gold;
        Platinum = platinum;
        Emerald = emerald;
        Diamond = diamond;
        Master = master;
        GrandMaster = grandMaster;
    }
    public float GetWeight(GrandType grand) //  등급에 따른 가중치 반환
    {
        switch (grand)
        {
            case GrandType.Bronze:
                return Bronze;

            case GrandType.Sliver:
                return Sliver;

            case GrandType.Gold:
                return Gold;

            case GrandType.Platinum:
                return Platinum;

            case GrandType.Emerald:
                return Emerald;

            case GrandType.Diamond:
                return Diamond;

            case GrandType.Master:
                return Master;

            case GrandType.GrandMaster:
                return GrandMaster;

            default:
                return 0f;
        }
    }
}
