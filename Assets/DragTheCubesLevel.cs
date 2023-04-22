using UnityEngine;

[CreateAssetMenu(fileName = "DragTheCubesLevel", menuName = "ScriptableObjects/DragTheCubesLevel", order = 1)]
public class DragTheCubesLevel : ScriptableObject
{
    public int[] correctCells;
    public Material instructions;

    public GameObject model;

    public GameObject[] cubes;
}
