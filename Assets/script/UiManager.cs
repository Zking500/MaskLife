using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager inst;

    [Header("Panels")]
    public GameObject PausePanel;
    public GameObject SettingsPanel;

    [Header("Buttons")]
    public Button ContinueButton;
    public Button SettingsButton;
    public Button BackButton;
    public Button ExitButton;

    [Header("Settings")]
    public Slider SensitivitySlider;
    public Camara camara;

    public bool Pause;

    void Awake()
    {
        inst = this;

        if (ContinueButton != null)
            ContinueButton.onClick.AddListener(ResumeGame);

        if (SettingsButton != null)
            SettingsButton.onClick.AddListener(OpenSettings);

        if (BackButton != null)
            BackButton.onClick.AddListener(BackToPause);

        if (ExitButton != null)
            ExitButton.onClick.AddListener(QuitGame);

        if (SensitivitySlider != null)
            SensitivitySlider.onValueChanged.AddListener(ChangeSensitivity);
    }

    void Start()
    {
        Pause = false;
        Time.timeScale = 1f;

        PausePanel.SetActive(false);
        SettingsPanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (camara != null && SensitivitySlider != null)
            SensitivitySlider.value = camara.Sensibilidad;
    }

    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape))
            return;

        // 🔥 SI ESTÁS EN SETTINGS → REGRESAR A PAUSA
        if (SettingsPanel.activeSelf)
        {
            BackToPause();
            return;
        }

        // 🔥 TOGGLE NORMAL
        if (Pause)
            ResumeGame();
        else
            ShowPause();
    }

    // ===== PAUSA =====

    public void ShowPause()
{
    Pause = true;

    // 🔥 BLOQUEAR CÁMARA ANTES DE TODO
    if (camara != null)
        camara.BloquearInput();

    PausePanel.SetActive(true);
    SettingsPanel.SetActive(false);

    Time.timeScale = 0f;
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
}



    public void ResumeGame()
{
    Pause = false;

    PausePanel.SetActive(false);
    SettingsPanel.SetActive(false);

    Time.timeScale = 1f;
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;

    // 🔥 DESBLOQUEAR CÁMARA
    if (camara != null)
        camara.DesbloquearInput();
}


    // ===== SETTINGS =====

    void OpenSettings()
    {
        PausePanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }

    void BackToPause()
    {
        SettingsPanel.SetActive(false);
        PausePanel.SetActive(true);
    }

    void ChangeSensitivity(float value)
    {
        if (camara != null)
            camara.Sensibilidad = value;
    }

    void QuitGame()
    {
        Application.Quit();
        Debug.Log("Salir del juego");
    }
}
