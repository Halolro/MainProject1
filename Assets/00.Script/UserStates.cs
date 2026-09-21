using System.IO;
using System.Xml;
using UnityEngine;

public class UserStates : MonoBehaviour
{
    
    public static UserStates instance;

    private int gold;
    protected int level;
    public int Level => level;
    private string userName;
    public int Gold => gold;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void UseGold(int num)
    {
        gold -= num;
    }

    public void SetUserName()   // 해당 함수는 초기 유저 이름을 정할때 사용하는 함수로 게임 시작하는 Ui화면에서 이름 적은뒤 새로 생성할때 딱 한번 사용할 함수임
    {
        //  현재는 해당 스크립트에 userName이라는 변수가 있으나 Ui쪽으로 옮길때는 함수안에 변수를 제작해주기 바람
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes"));

        XmlNode root = xmlDoc.CreateNode(XmlNodeType.Element, "UesrInfo", string.Empty);

        xmlDoc.AppendChild(root);

        // 유저 이름 저장
        XmlNode nameNode = xmlDoc.CreateElement("UserName");
        nameNode.InnerText = userName;
        root.AppendChild(nameNode);

        // 에셋의 Resources라는 폴더에 생성 및 저장이기에 Resources라는 폴더를 만들어주세요
        xmlDoc.Save("./Assets/Resources/UesrInfo.xml");
    }
    public void GetUserName()
    {
        TextAsset xmlFile = Resources.Load<TextAsset>("UesrInfo");

        if (xmlFile == null)
        {
            // 해당 Debug는 나중에 테스트끝나고 삭제 가능
            Debug.Log("UesrInfo.xml 파일이 없습니다.");
            return;
        }

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xmlFile.text);

        XmlNode nameNode = xmlDoc.SelectSingleNode("/UesrInfo/UserName");

        if (nameNode != null)
        {
            userName = nameNode.InnerText;
        }
        // 해당 Debug는 로딩이 끝나고 인게임 들어왔을때 이름 Ui칸에 넣을 코드라 나중에 수정
        Debug.Log("불러온 유저 이름 : " + userName);
    }
}
