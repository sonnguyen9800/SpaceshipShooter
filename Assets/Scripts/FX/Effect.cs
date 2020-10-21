using UnityEngine;
[System.Serializable]
public class Effect
{
    [SerializeField] private GameObject vfxObject ;
    public GameObject VFX => vfxObject; 
    [SerializeField] public EffectType type;
    public EffectType EffectType => type;

    private GameObject owner;


}
