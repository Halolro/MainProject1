using UnityEngine;
using System.Xml;
using System.IO;

public class FishingItem : MonoBehaviour
{
    protected int fishingRodNumber;
    protected int floatNumber;

    private string fileSave;
    private void Awake()
    {
        fileSave = Path.Combine(Application.persistentDataPath, "FishingItem.xml");
        SetFishingItem();
    }

    void Update()
    {
        
    }

    public void GetFishingItem()    // 게임을 킬때 마지막으로 저장된 낚시대 정보 불러오기
    {
        // 아무런 정보가 없을때 기본으로 초기화
        if(!File.Exists(fileSave))
        {
            Debug.Log("아이템에 관련된 정보가 없습니다.");

            fishingRodNumber = 1;
            floatNumber = 1;

            SetFishingItem();


            return;
        }

        // 아이템들 정보 불러오는 부분
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(fileSave);

        XmlNode rodNode = xmlDoc.SelectSingleNode("FishingItem/FishingRod");
        XmlNode floatNode = xmlDoc.SelectSingleNode("FishingItem/Float");

        if (rodNode != null)
        {
            fishingRodNumber = int.Parse(rodNode.InnerText);
        }
        if (floatNode != null)
        {
            floatNumber = int.Parse(floatNode.InnerText);
        }

        // 낚시대와 찌 정보 불러오는 Ui 텍스트 연결 부분(나중에 낚시대 번호와 찌 번호는 제거 테스트용으로 확인할때 써보기)
        Debug.Log($"아이템 정보 불러오기 완료! 낚시대 번호: {fishingRodNumber}, 찌 번호: {floatNumber}");
    }

    public void SetFishingItem()    // 낚시대 변경시 낚시대 정보 Xml에 저장
    {
        // 기본 아이템 정보 저장
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes"));

        XmlNode root = xmlDoc.CreateNode(XmlNodeType.Element, "FishingItem", string.Empty);

        xmlDoc.AppendChild(root);

        // 낚시대 정보 저장
        XmlNode rodNode = xmlDoc.CreateElement("FishingRod");
        rodNode.InnerText = fishingRodNumber.ToString();
        root.AppendChild(rodNode);

        // 낚시대 찌 정보 저장
        XmlNode floatNode = xmlDoc.CreateElement("Float");
        floatNode.InnerText = floatNumber.ToString();
        root.AppendChild(floatNode);

        // Xml 저장
        xmlDoc.Save(fileSave);
    }

    public void ChangFishRod(int num)   //  낚시대 바꾸기 
    {
        fishingRodNumber = num;

        SetFishingItem();
    }

    public void ChangFishFloat(int num) //  낚시 찌 바꾸기 
    {
        floatNumber = num;

        SetFishingItem();
    }
}
