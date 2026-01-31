using UnityEngine;
using UnityEngine.UI; // Necesario para controlar el Slider

public class ControladorMascara : MonoBehaviour
{
    [Header("Configuración de Durabilidad")]
    public float durabilidadMaxima = 100f;
    public float tasaDesgaste = 10f; // Puntos por segundo
    private float durabilidadActual;

    [Header("Referencias de Objetos")]
    public GameObject modeloMascara3D; // El objeto que el jugador ve
    public Slider barraUI;             // La barra que creamos en el Canvas

    private bool laTienePuesta = false;
    private bool estaRota = false;

    void Start()
    {
        durabilidadActual = durabilidadMaxima;

        // Configurar la barra al inicio
        barraUI.maxValue = durabilidadMaxima;
        barraUI.value = durabilidadActual;

        // Empezamos con todo oculto
        modeloMascara3D.SetActive(false);
        barraUI.gameObject.SetActive(false);
    }

    void Update()
    {
        // Tecla 'M' para poner/quitar
        if (Input.GetKeyDown(KeyCode.M) && !estaRota)
        {
            AlternarMascara();
        }

        // Si la usa, desgastarla y actualizar UI
        if (laTienePuesta && !estaRota)
        {
            ProcesarMecanica();
        }
    }

    void AlternarMascara()
    {
        laTienePuesta = !laTienePuesta;

        modeloMascara3D.SetActive(laTienePuesta);
        barraUI.gameObject.SetActive(laTienePuesta); // La barra solo se ve si usa la máscara
    }

    void ProcesarMecanica()
    {
        // Restar vida
        durabilidadActual -= tasaDesgaste * Time.deltaTime;

        // Actualizar la barra visualmente
        barraUI.value = durabilidadActual;

        // Comprobar si se rompió
        if (durabilidadActual <= 0)
        {
            RomperMascara();
        }
    }

    void RomperMascara()
    {
        durabilidadActual = 0;
        barraUI.value = 0;
        estaRota = true;
        laTienePuesta = false;

        modeloMascara3D.SetActive(false);
        barraUI.gameObject.SetActive(false);

        Debug.Log("MÁSCARA ROTA: El jugador es vulnerable.");
    }
}
