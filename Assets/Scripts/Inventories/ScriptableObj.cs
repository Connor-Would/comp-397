using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObj/New")]
public class ScriptableObj : ScriptableObject
{
    public string ItemName;
    public bool isStackable = false;
    public Texture icon;
    public GameObject prefab;
} //values remain changed even when running