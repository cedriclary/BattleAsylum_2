using UnityEngine;
using System.Collections;


public class CarteAléatoire : MonoBehaviour {

    public void LoadScene()
    {
        PlayerPrefs.SetInt("ctr", 0);
        PlayerPrefs.SetInt("ScoreP1", 0);
        PlayerPrefs.SetInt("ScoreP2", 0);
        Application.LoadLevel(Random.Range(1, 4));
    }

}
