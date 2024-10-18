using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TerrainGenerator))]
public class TerrainEditor : Editor
{

    public override void OnInspectorGUI()
    {


        // Add a button to the Inspector
        if (GUILayout.Button("Generate New Terrain"))
        {
            // Casting the target to TerrainGenerator so we can access its methods and properties
            TerrainGenerator terrain = (TerrainGenerator)target;

            // Call the method when button is clicked
            terrain.GenerateTerrain();
        }
    }
}