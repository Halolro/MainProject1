using System.Xml;
using System.IO;

public enum GrandType   // 물고기 희귀도 분류
{
    Bronze,
    Sliver,
    Gold,
    Platinum,
    Emerald,
    Diamond,
    Master,
    GrandMaster
}
public class FishingType
{
    protected GrandType grand;
    public GrandType Grand => grand;

    public string Name { get; protected set; }  // 물고기 이름
    public string Description { get; protected set; }   // 물고기 설명
    public float Probability {  get; protected set; }   // 물고기 잡힐 확률
    public int Gold {  get; protected set; }    // 물고기 값어치

}


class Goby : FishingType
{
    public Goby()
    {
        Name = "망둥어";
        Description = "처음에 매우 잡히기 쉬운 물고기";
        Probability = 30f;
        Gold = 200;
        grand = GrandType.Bronze;
    }
}

class SandSmelt : FishingType
{
    public SandSmelt()
    {
        Name = "보리멸치";
        Description = "무리지어 다니기때문에 금방 잡히는 물고기";
        Probability = 23.4f;
        Gold = 400;
        grand = GrandType.Bronze;
    }
}

class Halfbeak : FishingType
{
    public Halfbeak()
    {
        Name = "학꽁치";
        Description = "입이 작아서 잡기 힘드나 장비만 갖추면 자주 잡히는 물고기";
        Probability = 12.6f;
        Gold = 600;
        grand = GrandType.Sliver;
    }
}

class JackMackerel : FishingType
{
    public JackMackerel()
    {
        Name = "전갱이";
        Description = "낚시를 좀 하다보면 볼수 있는 물고기";
        Probability = 10.2f;
        Gold = 900;
        grand = GrandType.Sliver;
    }
}

class Mackerel : FishingType
{
    public Mackerel()
    {
        Name = "고등어";
        Description = "성질이 급해서 자주 잡히지는 않는 물고기";
        Probability = 7.5f;
        Gold = 1300;
        grand = GrandType.Gold;
    }
}

class Filefish : FishingType
{
    public Filefish()
    {
        Name = "쥐치";
        Description = "생각보다 흔히 보이지 않는 물고기";
        Probability = 4.3f;
        Gold = 1800;
        grand = GrandType.Gold;
    }
}

class Rockfish : FishingType
{
    public Rockfish()
    {
        Name = "우럭";
        Description = "암초에 살아서 잡기 까다로운 물고기";
        Probability = 3.2f;
        Gold = 2100;
        grand = GrandType.Platinum;
    }
}

class Flounder : FishingType
{
    public Flounder()
    {
        Name = "광어";
        Description = "바닥에 붙어살기 때문에 잡기 어려운 물고기";
        Probability = 2.6f;
        Gold = 2400;
        grand = GrandType.Platinum;
    }
}

class Bass : FishingType
{
    public Bass()
    {
        Name = "농어";
        Description = "큰 몸집과 체력때문에 잡기 힘든 물고기";
        Probability = 1.7f;
        Gold = 2900;
        grand = GrandType.Emerald;
    }
}

class RedSnapper : FishingType
{
    public RedSnapper()
    {
        Name = "참돔";
        Description = "물고기 자체가 보기 드문 물고기";
        Probability = 1.1f;
        Gold = 3600;
        grand = GrandType.Emerald;
    }
}

class Opaleye : FishingType
{
    public Opaleye()
    {
        Name = "뱅에돔";
        Description = "보기가 드물며 힘이 좋아 잡기 힘든 물고기";
        Probability = 1f;
        Gold = 4000;
        grand = GrandType.Diamond;
    }
}

class BlackPorgy : FishingType
{
     public BlackPorgy()
    {
        Name = "감성돔";
        Description = "물고기가 보기 드물며 경계심이 강해 잡기 힘들다";
        Probability = 0.8f;
        Gold = 4500;
        grand = GrandType.Diamond;
    }
}

class RockBream : FishingType
{
    public RockBream()
    {
        Name = "돌돔";
        Description = "보기가 드물며 턱힘이 쎄 놓칠 확률이 높은 물고기";
        Probability = 1.2f;
        Gold = 4300;
        grand = GrandType.Master;
    }
}

class EpinephelusAkaara : FishingType
{
    public EpinephelusAkaara()
    {
        Name = "붉은다금바리";
        Description = "잡으면 불법이나 비밀리에 거래되는 물고기";
        Probability = 0.1f;
        Gold = 9000;
        grand = GrandType.GrandMaster;
    }
}

class NiphonSpinosus : FishingType
{
    public NiphonSpinosus()
    {
        Name = "다금바리";
        Description = "특정지역에서 매우 극악의 확률로 보이는 물고기";
        Probability = 0.3f;
        Gold = 5400;
        grand = GrandType.Master;
    }
}