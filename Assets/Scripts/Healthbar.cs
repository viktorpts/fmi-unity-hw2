using UnityEngine;

public class Healthbar : MonoBehaviour
{
    public GameObject target;

    private RectTransform wipe;
    private float currentHp = 0;
    private int targetHp = 0;
    private int max = 0;

    void Awake()
    {
        wipe = transform.GetChild(1).gameObject.GetComponent<RectTransform>();
        target.GetComponent<Health>().OnHpUpdate += this.OnHpUpdate;
    }

    void OnHpUpdate(int oldAmount, int newAmount, int maxAmount)
    {
        currentHp = oldAmount;
        targetHp = newAmount;
        max = maxAmount;
    }

    void Update()
    {
        if (currentHp > targetHp)
        {
            currentHp -= 0.25f;
            float width = (currentHp / max) * 200f;
            wipe.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
        }
    }
}
