using UnityEngine;
using UnityEngine.UI; // Jika menggunakan UI.Text
// using TMPro; // Uncomment jika menggunakan TextMeshPro
using UnityEngine.SceneManagement;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialText; // Referensi ke GameObject teks tutorial
    public float displayDuration ; // Durasi tampilan setiap pesan tutorial
    private string[] ShowMassage = {
        "Selamat datang di permainan! \nTekan panah kanan untuk bergerak.",
        "Tekan panah atas untuk lompat!",
        "Hati-hati, musuh ada di depan!",
        "Selamat bermain dan semoga sukses!"
    };
    private int currentMessageIndex = 0;

    void Start()
    {
        ShowMessage(); // Mulai menampilkan pesan tutorial
    }

    void ShowMessage()
    {
        if (currentMessageIndex < ShowMassage.Length)
        {
            tutorialText.GetComponent<TextMeshProUGUI>().text = ShowMassage[currentMessageIndex]; // Mengatur teks menjadi pesan tutorial saat ini
            tutorialText.SetActive(true); // Menampilkan teks
            Invoke("NextMessage", displayDuration); // Panggil fungsi NextMessage setelah durasi tertentu
        }
        else
        {
            // Jika semua pesan sudah ditampilkan, sembunyikan teks dan pindah ke scene game
            HideTutorial();
        }
    }

    void NextMessage()
    {
        currentMessageIndex++; // Pindah ke pesan berikutnya
        ShowMessage(); // Tampilkan pesan berikutnya
    }

    void HideTutorial()
    {
        tutorialText.SetActive(false); // Menghilangkan teks tutorial
        // SceneManager.LoadScene("NamaSceneGame"); // Uncomment untuk pindah ke scene game
    }

}
