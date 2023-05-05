using UnityEngine;

[CreateAssetMenu(fileName = "ThrowYourChoiceLevel", menuName = "ScriptableObjects/ThrowYourChoiceLevel", order = 1)]
public class ThrowYourChoiceLevel : ScriptableObject
{
    public Material correctMaterial;
    public Material[] otherMaterials;

    public GameObject model;
}
