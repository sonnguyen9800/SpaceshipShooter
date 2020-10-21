using UnityEngine;
[CreateAssetMenu(menuName = "EffectFactory", fileName = "EffectFactory")]

public class EffectFactory : ScriptableObject
{
    [SerializeField] private Effect[] effects;

    public Effect FindEffect(EffectType type){
        foreach (Effect effect in this.effects){
            if (effect.type == type){
                return effect;
            }
        }
        return null;
    }

}
