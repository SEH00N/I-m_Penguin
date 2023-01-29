using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    [SerializeField] int maxMoney = 99999999;

    private int money = 0;

    /// <summary>
    /// 돈 획득 메소드
    /// </summary>
    /// <param name="amount">획득량</param>
    public void AddMoney(int amount)
    {
        int modifiedAmount = Mathf.Min(maxMoney, money + amount) - money;
        money += modifiedAmount;
    
        MoneyAddEffect(modifiedAmount);
    }

    /// <summary>
    /// 돈 사용 메소드
    /// <br/>
    /// 현재 돈이 코스트보다 적으면 돈이 깎이지 않음
    /// </summary>
    /// <param name="cost">소비량</param>
    /// <returns>able to use money</returns>
    public bool UseMoney(int cost)
    {
        if(money < cost)
            return false;

        money -= cost;
        MoneyUseEffect(cost);

        return true;
    }

    /// <summary>
    /// 돈 초기화
    /// </summary>
    public void ResetMoney() => money = 0;
    
    /// <summary>
    /// 돈 저장
    /// </summary>
    public void SaveMoney()
    {
        DataManager.Instance.userData.money = this.money;
        DataManager.Instance.SaveData<UserData>(DataManager.Instance.userData);
    }

    /// <summary>
    /// 현재 돈
    /// </summary>
    public int GetCurrentMoney() => money;

    /// <summary>
    /// 돈 획득 이펙트
    /// </summary>
    private void MoneyAddEffect(int amount) //구현 필요, 에셋 확보 후 구현 예정
    {

    }

    /// <summary>
    /// 돈 사용 이펙트
    /// </summary>
    private void MoneyUseEffect(int cost) //구현 필요, 에셋 확보 후 구현 예정
    {

    }
}
