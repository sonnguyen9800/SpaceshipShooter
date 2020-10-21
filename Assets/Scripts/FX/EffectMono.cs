using UnityEngine;

public class EffectMono : MonoBehaviour
{

    private Effect effect;
    private GameObject owner;
    private GameObject vfx;

    public GameObject Owner => owner;
    public Effect Effect => effect;

    public Effect GetEffect(){
        return this.effect;
    }

    public void SetEffect(Effect effect){
        this.effect = effect;
    }

        public void SetOwner(GameObject effect){
        this.owner = effect;
    }

    private void Awake()
    {
    }

    public void callEffect(){
        vfx = Instantiate(effect.VFX, transform.position, transform.rotation);

    }
    void Update() {
        if (this.owner == null) return;
        if (this.vfx == null) return;
        this.gameObject.transform.position = owner.transform.position;
        this.vfx.transform.position = owner.transform.position;
    }
}
