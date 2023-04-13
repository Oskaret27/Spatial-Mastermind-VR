using UnityEngine;

[CreateAssetMenu(fileName = "ShadowPuppetsLevel", menuName = "ScriptableObjects/ShadowPuppetsLevel", order = 1)]
public class ShadowPuppetsLevel : ScriptableObject
{
    public Material correctMaterial;
    public Material[] otherMaterials;

    public GameObject model;

}