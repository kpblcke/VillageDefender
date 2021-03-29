using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spell", menuName = "MagicSpell", order = 0)]
public class Spell : ScriptableObject
{
    [SerializeField]
    private List<Word> spellWords;
    [SerializeField]
    private Defender _defender;
    [SerializeField]
    private Sprite icon;
    [SerializeField] 
    private int cost;

    public List<Word> SpellWords => spellWords;

    public Defender Defender => _defender;

    public Sprite Icon => icon;

    public int Cost => cost;
}
