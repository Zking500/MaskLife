using UnityEngine;

public class PlayerMovimiento : MonoBehaviour
{
    public float Speed = 15f;
    public float Gravedad = -10f;

    public Transform EnElPiso;
    public float DistanciaDelSuelo = 0.4f;
    public LayerMask MascaraDelPiso;

    private CharacterController Controlador;
    private Vector3 velocidad;
    private bool EstaEnElPiso;

    void Start()
    {
        Controlador = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Detectar suelo
        EstaEnElPiso = Physics.CheckSphere(
            EnElPiso.position,
            DistanciaDelSuelo,
            MascaraDelPiso
        );

        if (EstaEnElPiso && velocidad.y < 0)
        {
            velocidad.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 mover = transform.right * x + transform.forward * z;

        // Movimiento horizontal
        Controlador.Move(mover * Speed * Time.deltaTime);

        // Gravedad
        velocidad.y += Gravedad * Time.deltaTime;
        Controlador.Move(velocidad * Time.deltaTime);
    }
}
