using UnityEngine;

public class Camara : MonoBehaviour
{
    public float Sensibilidad = 1000f;
    public Transform Player;

    float RotacionVertical = 0f;

    void Start()
    {
        //Bloquea el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;

        //Oculta el cursor mientras juegas
        Cursor.visible = false;
    }

    void Update()
    {
        //Nos dan los valores del mouse para mover
        float ValorX = Input.GetAxis("Mouse X") * Sensibilidad * Time.deltaTime;
        float ValorY = Input.GetAxis("Mouse Y") * Sensibilidad * Time.deltaTime;

        //Guarda el valor y queda en el valor para seguir
        RotacionVertical -= ValorY;
        RotacionVertical = Mathf.Clamp(RotacionVertical, -80, 80);

        //Hace la rotacion vertical fluida
        transform.localRotation = Quaternion.Euler(RotacionVertical, 0f, 0f);

        //Hce la rotacion horizontal
        if (Player != null) {
            Player.Rotate(Vector3.up * ValorX);
        }
        
    }
}
