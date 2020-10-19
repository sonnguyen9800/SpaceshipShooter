public enum CharacterType
{
    PLAYER,
    ENEMY
}
public interface ICharacter
{
    CharacterType GetCharacterType();
}
