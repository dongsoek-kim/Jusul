public interface ISkillBehaviour
{
    void Execute(SkillBase owner);
}

public interface ISkil
{
    void Active();
    void Deactive();
}
