using UnityEngine;
using TMPro;

public class GeldText : MonoBehaviour
{
    public player_movement player;
    public TextMeshProUGUI textElement;



    // Update is called once per frame
    void Update()
    {
         textElement.text = player.geld + "$";
       
            if (textElement == null)
                Debug.LogError("textElement ist NICHT zugewiesen!");

            if (player == null)
                Debug.LogError("player ist NICHT zugewiesen!");

            if (textElement != null && player != null)
                textElement.text = player.geld + "$";
        

    }
}
