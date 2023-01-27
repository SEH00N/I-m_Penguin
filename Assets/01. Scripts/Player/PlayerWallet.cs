using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    [SerializeField] int maxMoney;

    private int money;

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
    /// </summary>
    /// <param name="cost">소비량</param>
    public void UseMoney(int cost)
    {
        int modifiedCost = -(Mathf.Max(0, money - cost) - money);
        money -= modifiedCost;

        MoneyUseEffect(modifiedCost);
    }

    /// <summary>
    /// 돈 초기화
    /// </summary>
    public void ResetMoney() => money = 0;

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
