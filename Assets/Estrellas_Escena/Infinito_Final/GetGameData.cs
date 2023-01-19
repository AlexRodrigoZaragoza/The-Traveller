using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetGameData : MonoBehaviour
{
    GameObject infiniteInfo;
    public List<GamesData> GamesInfo = new List<GamesData>();

    public GameObject Parent;
    public GameObject Prefab;

    // Start is called before the first frame update

    private void Awake()
    {
        infiniteInfo = GameObject.Find("InfiniteMode");
        GamesInfo = SendGameData.GamesInfo;
    }

    void Start()
    {
        for (int i = 0; i < GamesInfo.Count; i++)
        {
            GameObject newScore = Instantiate(Prefab, Parent.transform);

            Text[] newText;
            newText = newScore.GetComponentInChildren<Button>().GetComponentsInChildren<Text>();
            newText[0].text = GamesInfo[i].Minigame;
            newText[1].text = GamesInfo[i].Result;
        }
        //SendGameData.GamesInfo.Clear();
    }

    public void Volver()
    {
        Destroy(infiniteInfo);
        SendGameData.GamesInfo.Clear();
        SceneManager.LoadScene("EscenaInicial");
    }
}
