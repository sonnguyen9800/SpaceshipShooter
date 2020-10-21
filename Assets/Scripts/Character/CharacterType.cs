public enum CharacterType
{
    Player,
    Enemy
}
public interface ICharacter
{
    CharacterType CharacterType { get; }
}
