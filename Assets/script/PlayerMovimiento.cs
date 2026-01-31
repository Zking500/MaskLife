using UnityEngine;

public class PlayerMovimiento : MonoBehaviour
{
    [Header("Movimiento")]
    public float Speed = 8f;
    public float RunSpeed = 11f;

    [Header("Salto")]
    public float JumpForce = 1f;
    public float Gravedad = -30f;
    public float JumpCooldown = 1.5f;

    private CharacterController controlador;
    private Vector3 velocidad;
    private float cooldownTimer = 0f;

    void Start()
    {
        controlador = GetComponent<CharacterController>();
        controlador.stepOffset = 0.5f;
        JumpForce = 1f;
        Gravedad = -30f;
        JumpCooldown = 1.5f;
    }

    void Update()
    {
        // No moverse si el juego está en pausa
        if (UiManager.inst != null && UiManager.inst.Pause)
            return;

        bool estaEnElPiso = controlador.isGrounded;

        // Mantener al jugador pegado al suelo
        if (estaEnElPiso && velocidad.y < 0)
            velocidad.y = -2f;

        // ⏱️ Cooldown del salto
        if (cooldownTimer > 0f)
            cooldownTimer -= Time.deltaTime;

        // Input de movimiento
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        float velocidadActual = Input.GetKey(KeyCode.LeftShift)
            ? RunSpeed
            : Speed;

        Vector3 mover = transform.right * x + transform.forward * z;
        controlador.Move(mover * velocidadActual * Time.deltaTime);

        // 🦘 Salto (con cooldown real)
        if (Input.GetKeyDown(KeyCode.Space) && estaEnElPiso && cooldownTimer <= 0f)
        {
            velocidad.y = Mathf.Sqrt(JumpForce * -2f * Gravedad);
            cooldownTimer = JumpCooldown;
        }

        // 🌍 Gravedad (caída más rápida que la subida)
        if (velocidad.y < 0)
            velocidad.y += Gravedad * 1.5f * Time.deltaTime;
        else
            velocidad.y += Gravedad * Time.deltaTime;

        controlador.Move(velocidad * Time.deltaTime);
    }
}
