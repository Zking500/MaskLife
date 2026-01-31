using UnityEngine;

public class Camara : MonoBehaviour
{
    [Range(50f, 1000f)]
    public float Sensibilidad = 500f;

    public Transform Player;

    float RotacionVertical = 0f;
    private bool inputBloqueado = false;

    void Update()
    {
        // 🔥 Bloqueo inmediato
        if (inputBloqueado)
            return;

        float mouseX = Input.GetAxisRaw("Mouse X") * Sensibilidad * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Sensibilidad * Time.deltaTime;

        RotacionVertical -= mouseY;
        RotacionVertical = Mathf.Clamp(RotacionVertical, -80f, 80f);

        transform.localRotation = Quaternion.Euler(RotacionVertical, 0f, 0f);
        Player.Rotate(Vector3.up * mouseX);
    }

    // 🔥 Métodos públicos para el UiManager
    public void BloquearInput()
    {
        inputBloqueado = true;
    }

    public void DesbloquearInput()
    {
        inputBloqueado = false;
    }
}
