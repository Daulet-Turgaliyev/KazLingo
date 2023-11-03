using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Tool/Clear Saves")]
public class RemoveAllSaves : EditorWindow
{
    [MenuItem("Tools/Delete PlayerPrefs")]
    static void Init()
    {
        RemoveAllSaves window = GetWindow<RemoveAllSaves>();
        window.titleContent = new GUIContent("Delete PlayerPrefs");
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("Are you sure you want to delete all PlayerPrefs data?");
        if (GUILayout.Button("Delete PlayerPrefs"))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("PlayerPrefs data deleted.");
        }
    }
}
