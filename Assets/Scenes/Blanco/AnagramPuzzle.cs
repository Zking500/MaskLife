using UnityEngine;
using TMPro;

public class AnagramPuzzle : MonoBehaviour
{
    public TMP_Text anagramText;
    public TMP_InputField inputField;
    public TMP_Text resultText;

    public string correctPhrase = "LA MUERTE ROJA";

    void OnEnable()
    {
        anagramText.text = ShuffleString(correctPhrase);
        inputField.text = "";
        resultText.text = "";
    }

    public void CheckAnswer()
    {
        string playerAnswer = inputField.text.ToUpper().Trim();

        if (playerAnswer == correctPhrase)
        {
            resultText.text = "Correcto.";
            resultText.color = Color.green;
            Invoke(nameof(ClosePuzzle), 1.5f);
        }
        else
        {
            resultText.text = "Incorrecto.";
            resultText.color = Color.red;
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
