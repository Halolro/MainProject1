
public class FishItemType : FishingItem
{
    public FishingRodData FishingRodType()
    {
        switch (fishingRodNumber)
        {
            case 1:
                return new FishingRodData(10f, 0f, 0f, 0f, 0f, 0f, 0f, 0f);
            case 2:
                return new FishingRodData(4.5f, 5.5f, 0f, 0f, 0f, 0f, 0f, 0f);
            case 3:
                return new FishingRodData(3f, 4f, 3f, 0f, 0f, 0f, 0f, 0f);
            case 4:
                return new FishingRodData(0f, 2.5f, 4f, 3.5f, 0f, 0f, 0f, 0f);
            case 5:
                return new FishingRodData(0f, 0f, 4.5f, 3.5f, 2f, 0f, 0f, 0f);
            case 6:
                return new FishingRodData(0f, 0f, 2.5f, 3f, 3f, 1.5f, 0f, 0f);
            case 7:
                return new FishingRodData(0f, 0f, 0f, 3.5f, 3.5f, 3f, 0f, 0f);
            case 8:
                return new FishingRodData(0f, 0f, 0f, 0f, 3f, 4.5f, 2.5f, 0f);
            case 9:
                return new FishingRodData(0f, 0f, 0f, 0f, 1.5f, 3.5f, 4.5f, 0.5f);
            default:
                return new FishingRodData(10f, 0f, 0f, 0f, 0f, 0f, 0f, 0f);
        }
    }
    public void FishingFloatType()  //  낚시 찌 종류에 따른 효과 변경
    {
       switch (floatNumber)
        {
            case 1:
                FishManager.instance.FishCacheSpeedUp(6);
                break;
            case 2:
                FishManager.instance.FishCacheSpeedUp(10);
                break;
            case 3:
                FishManager.instance.FishCacheSpeedUp(15);
                break;
            case 4:
                FishManager.instance.FishCacheSpeedUp(24);
                break;
            case 5:
                FishManager.instance.FishCacheSpeedUp(31);
                break;
            case 6:
                FishManager.instance.FishCacheSpeedUp(40);
                break;
        }
    }
}

