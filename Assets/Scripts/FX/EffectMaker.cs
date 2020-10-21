using UnityEngine;

public class EffectMaker : MonoBehaviour
{
    [SerializeField] GameObject effectMonoGameObject;
    public static EffectMaker Instance { get; private set; }
    [SerializeField] private EffectFactory effectFactory;

    public void spawnEffect(GameObject otherTransform, EffectType effect)
    {

        GameObject go = Instantiate(effectMonoGameObject, this.transform.position, this.transform.rotation);
        EffectMono effectMono = go.GetComponent<EffectMono>();
        effectMono.SetEffect(this.effectFactory.FindEffect(effect));
        effectMono.SetOwner(otherTransform);
        effectMono.callEffect();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
