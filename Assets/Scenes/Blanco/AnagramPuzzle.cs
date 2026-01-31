using UnityEngine;
using TMPro;

public class AnagramPuzzle : MonoBehaviour
{
    public TMP_Text TextoAnagrama;
    public TMP_InputField InputRespuesta;
    public TMP_Text TextoResultado;

    public string correctPhrase = "LA MUERTE ROJA";

    void OnEnable()
    {
        TextoAnagrama.text = ShuffleString(correctPhrase);
        InputRespuesta.text = "";
        TextoResultado.text = "";
    }

    public void CheckAnswer()
    {
        string playerAnswer = InputRespuesta.text.ToUpper().Trim();

        if (playerAnswer == correctPhrase)
        {
            TextoResultado.text = "Correcto.";
            TextoResultado.color = Color.green;
            Invoke(nameof(ClosePuzzle), 1.5f);
        }
        else
        {
            TextoResultado.text = "Incorrecto.";
            TextoResultado.color = Color.red;
        }
    }

    void ClosePuzzle()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameObject.SetActive(false);
    }

    string ShuffleString(string input)
    {
        char[] chars = input.ToCharArray();

        for (int i = 0; i < chars.Length; i++)
        {
            int rnd = Random.Range(0, chars.Length);
            char temp = chars[i];
            chars[i] = chars[rnd];
            chars[rnd] = temp;
        }

        return new string(chars);
    }
}
