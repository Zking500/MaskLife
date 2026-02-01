// Assets/Editor/CreatePurpleMaterials.cs
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class CreatePurpleMaterials
{
    [MenuItem("Tools/Create Purple Room Materials")]
    static void CreateMaterials()
    {
        // Crear material base púrpura
        Material purpleMat = new Material(Shader.Find("Standard"));
        purpleMat.color = new Color(0.6f, 0.2f, 0.8f, 1.0f);
        purpleMat.name = "PurpleRoom_Walls";
        AssetDatabase.CreateAsset(purpleMat, "Assets/Materials/Rooms/PurpleRoom/PurpleRoom_Walls.mat");
        
        // Material lavanda para detalles
        Material lavenderMat = new Material(Shader.Find("Standard"));
        lavenderMat.color = new Color(0.9f, 0.6f, 1.0f, 1.0f);
        lavenderMat.name = "PurpleRoom_Details";
        AssetDatabase.CreateAsset(lavenderMat, "Assets/Materials/Rooms/PurpleRoom/PurpleRoom_Details.mat");
        
        // Material con brillo para efectos
        Material shinyPurple = new Material(Shader.Find("Standard"));
        shinyPurple.color = new Color(0.7f, 0.3f, 0.9f, 1.0f);
        shinyPurple.SetFloat("_Metallic", 0.8f);
        shinyPurple.SetFloat("_Glossiness", 0.9f);
        shinyPurple.name = "PurpleRoom_Shiny";
        AssetDatabase.CreateAsset(shinyPurple, "Assets/Materials/Rooms/PurpleRoom/PurpleRoom_Shiny.mat");
        
        Debug.Log("Materiales de habitación púrpura creados");
    }
}
#endif