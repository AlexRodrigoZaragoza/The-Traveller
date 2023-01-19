using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SendGameData : MonoBehaviour
{
    public static List<GamesData> GamesInfo = new List<GamesData>();

    public void AddNewInfo(string minigame, string result)
    {
        if (Seleccionar_Dificultad.infiniteMode)
        {
            GamesInfo.Add(new GamesData(minigame, result));
        }
    }

    public void ResetInfo()
    {
        GamesInfo.Clear();
    }

    public void EndTravel()
    {
        DontDestroyOnLoad(transform.gameObject);

        SceneManager.LoadScene("Historia_Feedback");
    }

    public void goBacktoMenu()
    {
        SceneManager.LoadScene("EscenaInicial");
        Destroy(this.gameObject);
    }

}
