using UnityEngine;





public class Startscreen : MonoBehaviour
{
    public void Beenden()      
    {
        Application.Quit();     
        Debug.Log("Spiel wird beendet.");
    }

    public void StartSpiel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene"); // Ersetze mit deinem echten Szenennamen
    }
}

