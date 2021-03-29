using UnityEngine;


[CreateAssetMenu(fileName = "Word", menuName = "MagicWord", order = 0)]
public class Word : ScriptableObject
{
    [SerializeField]
    private Sprite wordImage;

    public Sprite WordImage => wordImage;
}
