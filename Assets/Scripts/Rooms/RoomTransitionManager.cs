// Assets/Scripts/Rooms/RoomTransitionManager.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTransitionManager : MonoBehaviour
{
    public enum RoomSequence
    {
        Blue,       // Nacimiento
        Purple,     // Infancia
        Green,      // Juventud
        Orange,     // Madurez
        White,      // Vejez
        Violet,     // Muerte inminente
        Black       // Muerte
    }
    
    public RoomSequence currentRoom = RoomSequence.Purple;
    
    void Start()
    {
        LoadRoom(currentRoom);
    }
    
    public void LoadRoom(RoomSequence room)
    {
        string sceneName = GetSceneNameForRoom(room);
        
        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            SceneManager.LoadScene(sceneName);
            currentRoom = room;
            Debug.Log("Cargando habitación: " + room.ToString());
        }
        else
        {
            Debug.LogWarning("Escena no encontrada: " + sceneName);
        }
    }
    
    public void GoToNextRoom()
    {
        // Avanzar en la secuencia de habitaciones
        int nextRoomIndex = ((int)currentRoom + 1) % System.Enum.GetValues(typeof(RoomSequence)).Length;
        currentRoom = (RoomSequence)nextRoomIndex;
        LoadRoom(currentRoom);
    }
    
    string GetSceneNameForRoom(RoomSequence room)
    {
        switch (room)
        {
            case RoomSequence.Blue: return "BlueRoom";
            case RoomSequence.Purple: return "PurpleRoom";
            case RoomSequence.Green: return "GreenRoom";
            case RoomSequence.Orange: return "OrangeRoom";
            case RoomSequence.White: return "WhiteRoom";
            case RoomSequence.Violet: return "VioletRoom";
            case RoomSequence.Black: return "BlackRoom";
            default: return "PurpleRoom";
        }
    }
    
    void Update()
    {
        // Teclas para navegar entre habitaciones (para pruebas)
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GoToNextRoom();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Ir a habitación anterior
            int prevRoomIndex = ((int)currentRoom - 1 + System.Enum.GetValues(typeof(RoomSequence)).Length) 
                % System.Enum.GetValues(typeof(RoomSequence)).Length;
            currentRoom = (RoomSequence)prevRoomIndex;
            LoadRoom(currentRoom);
        }
    }
}