
public class UserData : Data
{
    public int money = 0;

    public override void Generate()
    {
        money = 0;
    }

    public override bool IsNull() => false;

    public override void Save()
    {
        
    }
}
