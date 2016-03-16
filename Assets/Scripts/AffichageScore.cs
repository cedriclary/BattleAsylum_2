using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AffichageScore : MonoBehaviour {

    public Text P1score;
    public Text P2score;

    private int p1;
    private int p2;

    void Start()
    {
        p1 = PlayerPrefs.GetInt("ScoreP1");
        p2 = PlayerPrefs.GetInt("ScoreP2");
        P1score.text = p1.ToString();
        P2score.text = p2.ToString();
        StartCoroutine(waitCoroutine4());
    }

    IEnumerator waitCoroutine4()
    {
        yield return new WaitForSeconds(5);
        Application.LoadLevel(0);
    }
}
