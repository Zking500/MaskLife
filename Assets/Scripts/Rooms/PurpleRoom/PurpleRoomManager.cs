// Assets/Scripts/Rooms/PurpleRoom/PurpleRoomManager.cs
using UnityEngine;
using System.Collections;

public class PurpleRoomManager : MonoBehaviour
{
    // Símbolos de la habitación púrpura (infancia/vitalidad)
    [Header("Elementos Simbólicos")]
    public GameObject symbolicToys;           // Juguetes que representan infancia
    public Light roomLight;                   // Luz cálida de vitalidad
    public AudioSource childhoodSounds;       // Sonidos de infancia
    public ParticleSystem vitalityParticles;  // Partículas de energía/vitalidad
    
    [Header("Configuración de Color")]
    public Color purpleColor = new Color(0.6f, 0.2f, 0.8f, 1.0f);
    public Color lavenderColor = new Color(0.9f, 0.6f, 1.0f, 1.0f);
    
    [Header("Configuración Temporal")]
    public float roomDuration = 60f;          // Tiempo en la habitación
    private float timeSpent = 0f;
    
    void Start()
    {
        InitializePurpleRoom();
        StartCoroutine(RoomExperience());
    }
    
    void InitializePurpleRoom()
    {
        // Configurar colores de la habitación
        RenderSettings.fogColor = purpleColor;
        RenderSettings.fog = true;
        
        // Configurar iluminación
        if (roomLight != null)
        {
            roomLight.color = lavenderColor;
            roomLight.intensity = 1.5f;
        }
        
        // Iniciar partículas de vitalidad
        if (vitalityParticles != null)
        {
            var main = vitalityParticles.main;
            main.startColor = lavenderColor;
            vitalityParticles.Play();
        }
        
        Debug.Log("Habitación Púrpura Inicializada - Símbolo: Infancia/Vitalidad");
    }
    
    IEnumerator RoomExperience()
    {
        // Fase 1: Infancia (primeros 20 segundos)
        PlayChildhoodPhase();
        yield return new WaitForSeconds(20f);
        
        // Fase 2: Transición a crecimiento
        TransitionToGrowth();
        yield return new WaitForSeconds(20f);
        
        // Fase 3: Preparación para siguiente habitación
        PrepareForNextRoom();
        yield return new WaitForSeconds(20f);
        
        // Fin de la experiencia en la habitación
        OnRoomComplete();
    }
    
    void PlayChildhoodPhase()
    {
        // Activar elementos de infancia
        if (symbolicToys != null) symbolicToys.SetActive(true);
        if (childhoodSounds != null) childhoodSounds.Play();
        
        // Efectos visuales de infancia
        StartCoroutine(PulseLight(0.8f, 1.2f, 2f));
    }
    
    void TransitionToGrowth()
    {
        // Cambiar de infancia a crecimiento
        if (vitalityParticles != null)
        {
            var emission = vitalityParticles.emission;
            emission.rateOverTime = 50f; // Aumentar partículas
        }
    }
    
    void PrepareForNextRoom()
    {
        // Reducir intensidad gradualmente
        StartCoroutine(FadeRoom());
    }
    
    void OnRoomComplete()
    {
        // Evento cuando se completa la habitación
        Debug.Log("Habitación Púrpura completada. Transición a siguiente etapa.");
        // Aquí iría la transición a la siguiente habitación
    }
    
    IEnumerator PulseLight(float minIntensity, float maxIntensity, float duration)
    {
        // Efecto de luz palpitante (como latidos de infancia)
        float elapsedTime = 0f;
        
        while (elapsedTime < duration)
        {
            if (roomLight != null)
            {
                float t = Mathf.PingPong(elapsedTime * 2f, 1f);
                roomLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, t);
            }
            
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
    
    IEnumerator FadeRoom()
    {
        // Fundido gradual al salir de la habitación
        float fadeDuration = 5f;
        float elapsedTime = 0f;
        float initialIntensity = roomLight.intensity;
        
        while (elapsedTime < fadeDuration)
        {
            if (roomLight != null)
            {
                roomLight.intensity = Mathf.Lerp(initialIntensity, 0.1f, elapsedTime / fadeDuration);
            }
            
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
    
    void Update()
    {
        timeSpent += Time.deltaTime;
        
        // Control por teclas para pruebas
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayChildhoodPhase();
        }
    }
}