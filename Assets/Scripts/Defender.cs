using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] private int manaCost;

    public void AddMana(int amount)
    {
        FindObjectOfType<ManaDisplay>().AddMana(amount);
    }

    public int GetManaCost()
    {
        return manaCost;
    }
}
