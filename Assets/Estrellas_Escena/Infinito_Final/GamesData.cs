using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GamesData
{
    public string Minigame;
    public string Result;

    public GamesData(string Minigame, string Result)
    {
        this.Minigame = Minigame;
        this.Result = Result;
    }
}
