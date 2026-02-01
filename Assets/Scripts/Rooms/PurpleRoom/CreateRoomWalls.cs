// Puedes crear un script para generar las paredes automáticamente:
// Assets/Scripts/Rooms/PurpleRoom/CreateRoomWalls.cs

using UnityEngine;

public class CreateRoomWalls : MonoBehaviour
{
    public Material wallMaterial;
    public float roomWidth = 20f;
    public float roomHeight = 5f;
    public float roomDepth = 15f;
    
    void Start()
    {
        CreateWall("NorthWall", new Vector3(0, roomHeight/2, roomDepth/2), 
                  new Vector3(roomWidth, roomHeight, 0.2f));
        CreateWall("SouthWall", new Vector3(0, roomHeight/2, -roomDepth/2), 
                  new Vector3(roomWidth, roomHeight, 0.2f));
        CreateWall("EastWall", new Vector3(roomWidth/2, roomHeight/2, 0), 
                  new Vector3(0.2f, roomHeight, roomDepth));
        CreateWall("WestWall", new Vector3(-roomWidth/2, roomHeight/2, 0), 
                  new Vector3(0.2f, roomHeight, roomDepth));
    }
    
    void CreateWall(string name, Vector3 position, Vector3 scale)
    {
        GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        wall.name = name;
        wall.transform.position = position;
        wall.transform.localScale = scale;
        
        if (wallMaterial != null)
        {
            wall.GetComponent<Renderer>().material = wallMaterial;
        }
        else
        {
            wall.GetComponent<Renderer>().material.color = 
                new Color(0.6f, 0.2f, 0.8f, 1f);
        }
    }
}