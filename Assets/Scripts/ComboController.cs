using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class ComboController : Singleton<ComboController>
{
    [SerializeField]
    private List<Word> allWords;
    [SerializeField]
    private List<Spell> allSpells;

    [SerializeField]
    private int maxWordsSpell = 2;

    [SerializeField]
    private List<Word> currentWords;

    [SerializeField]
    private ComboShow comboUI;

    private DefenderSpawner _defenderSpawner;
    private ManaDisplay _manaDisplay;
    
    private void Start()
    {
        _defenderSpawner = DefenderSpawner.instance;
        _manaDisplay = FindObjectOfType<ManaDisplay>();
    }

    public void AddWord(int i)
    {
        if (currentWords.Count >= maxWordsSpell)
        {
            return;
        }
        Word newWord = allWords[i];
        currentWords.Add(newWord);
        comboUI.AddWordImage(newWord.WordImage, currentWords.Count - 1);
    }

    public void CastWords()
    {
        foreach (var spell in allSpells)
        {
            if (spell.SpellWords.SequenceEqual(currentWords))
            {
                CastSpell(spell);
                return;
            }
        }
        CastSpell(null);
    }

    private void CastSpell(Spell spell)
    {
        if (spell)
        {
            _defenderSpawner.SelectNewDefender(spell.Defender);
            comboUI.ChangeSpell(spell);
        }
        else
        {
            _defenderSpawner.SelectNewDefender(null);
            comboUI.ClearSpell();
        }
        ResetWords();
        comboUI.ClearSlots();
    }

    private void ResetWords()
    {
        currentWords.Clear();
    }

    public void UseSpell()
    {
        _defenderSpawner.Cast();
    }
    
}
