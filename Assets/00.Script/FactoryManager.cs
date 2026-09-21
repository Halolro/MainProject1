using UnityEngine;

public class FactoryManager : MonoBehaviour
{
    public static FactoryManager instance;

    protected bool[] upGradeNum;
    protected bool unLock;
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

    public void UnLockFactory()
    {
        if (UserStates.instance.Gold >= 1500000)
        {
            unLock = true;
            UserStates.instance.UseGold(1500000);
            // 공장을 해금하였을때 Ui에 연결할 안내문
            Debug.Log("공장이 열렸습니다.");
        }
        else
        {
            // Ui에 연결하여 띄울 안내문
            Debug.Log("돈이 부족하여 공장을 개방할 수 없습니다.");
        }
    }
    public void UpGradeFactory()
    {
        if (UserStates.instance.Gold >= 3000000 && upGradeNum[1] == false)
        {
            UserStates.instance.UseGold(3000000);
            // 임시적인 것이며 나중에 정확한 어디를 업그레이드 했는지 수정할 것
            Debug.Log("공장을 업그레이드 하였습니다");
        }
        else
        {
            Debug.Log("돈이 부족하여 업그레이드를 실패하였습니다.");
        }
    }
}
