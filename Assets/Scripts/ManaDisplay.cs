using System;
using UnityEngine;
using UnityEngine.UI;

public class ManaDisplay : MonoBehaviour
{
    [SerializeField] private int mana = 100;
    private Text manaText;

    private void Start()
    {
        manaText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        manaText.text = mana.ToString();
    }

    public void AddMana(int amount)
    {
        mana += amount;
        UpdateDisplay();
    }

    public void SpendMana(int amount)
    {
        if (amount <= mana)
        {
            mana -= amount;
            UpdateDisplay();
        }
    }

    public bool HaveEnoughMana(int amount)
    {
        return mana >= amount;
    }
}