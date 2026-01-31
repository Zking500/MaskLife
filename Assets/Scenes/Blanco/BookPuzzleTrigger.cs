using UnityEngine;

public class BookPuzzleTrigger : MonoBehaviour
{
    public GameObject puzzleUI;

    private bool used = false;

private void OnTriggerEnter(Collider other)
{
    if (used) return;

    if (other.CompareTag("Player"))
    {
        used = true;
        puzzleUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}

}
