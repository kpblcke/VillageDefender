using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboShow : MonoBehaviour
{
    [SerializeField]
    private List<Image> slots;
    
    [SerializeField]
    private Image spell;
    [SerializeField] 
    private Text spellCost;

    [SerializeField] 
    private Sprite defaulImg;

    private void Start()
    {
        ClearSpell();
        ClearSlots();
    }

    public void ChangeSpell(Spell newSpell)
    {
        spell.sprite = newSpell.Icon;
        spellCost.text = newSpell.Cost.ToString();
    }

    public void ClearSpell()
    {
        spell.sprite = defaulImg;
        spellCost.text = "";
    }

    public void ClearSlots()
    {
        foreach (var slot in slots)
        {
            slot.sprite = null;
        }
    }

    public void AddWordImage(Sprite wordImage, int pos)
    {
        slots[pos].sprite = wordImage;
    }
}
