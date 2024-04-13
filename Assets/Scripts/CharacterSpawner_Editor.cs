using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CharacterSpawner))]
public class CharacterSpawner_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        CharacterSpawner gen = (CharacterSpawner)target;

        if (GUILayout.Button("Spawn Character"))
        {
            gen.SpawnCharacter();
        }
    }
}