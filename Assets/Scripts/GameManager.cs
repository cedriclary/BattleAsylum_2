using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public PlayerController p1;
    public PlayerController p2;

    public Text P1win;
    public Text P2win;

    Animator anim;
    private bool begin = true;
    private int scene;
    private int toLoadScene;
    private bool flag = false;
    private int nbrScene = 2;
    private bool p1score = false;
    private bool p2score = false;
    


	// Use this for initialization
	void Start ()
    {
        Debug.Log(PlayerPrefs.GetInt("ScoreP1"));
        Debug.Log(PlayerPrefs.GetInt("ScoreP2"));
        anim = GetComponent<Animator>();
        //Players obviously start with disabled controls.
        //The simplest way I found was to simply disable both PlayerController scripts.
        p1.enabled = false;
        p2.enabled = false;
        //This flag tells the game manager wether or not it has to play the countdown animation.
        begin = true;
        p1score = false;
        p2score = false;
        P1win.text = "";
        P2win.text = "";
        scene = Application.loadedLevel;
    }

    void Update()
    {
        if (begin)
        {
            anim.Play("CountDown");
            //waits for 3 seconds then calls the enableControls() function.
            Invoke("enableControls", 3);
            begin = false;
        }
        //This checks every frame if a player is dead.
        if (p1.isDead() || p2.isDead())
        {
            p1.enabled = false;
            p2.enabled = false;

            if (p1.isDead())
            {
                StartCoroutine(waitCoroutine());
                p2score = true;         
            }
            else if( p2.isDead())
            {
                StartCoroutine(waitCoroutine3());
                p1score = true;
            }
            StartCoroutine(waitCoroutine2());   
        }
    }
    
    IEnumerator waitCoroutine()
    {
        yield return new WaitForSeconds(1);
        P2win.text = "Le joueur 2 a remporté ce combat !";   
    }

    IEnumerator waitCoroutine3()
    {
        yield return new WaitForSeconds(1);
        P1win.text = "Le joueur 1 a remporté ce combat !";
    }

    IEnumerator waitCoroutine2()
    {
        yield return new WaitForSeconds(2);
        do
        {
            if (PlayerPrefs.GetInt("ctr") < nbrScene)
            {
                toLoadScene = Random.Range(1, 4);
                if (toLoadScene == scene)
                {
                    flag = false;
                }
                else
                {
                    if (p1score == true)
                    {
                        PlayerPrefs.SetInt("ScoreP1", PlayerPrefs.GetInt("ScoreP1") + 1);
                        PlayerController playerController = p2.GetComponent<PlayerController>();
                        playerController.dead = false;
                    }
                    else if (p2score == true)
                    {
                        PlayerPrefs.SetInt("ScoreP2", PlayerPrefs.GetInt("ScoreP2") + 1);
                        PlayerController playerController = p1.GetComponent<PlayerController>();
                        playerController.dead = false;
                    }
                    PlayerPrefs.SetInt("ctr", PlayerPrefs.GetInt("ctr") + 1);
                    flag = true;
                    Application.LoadLevel(toLoadScene);

                }
            }
            else
            {
                if (p1score == true)
                {
                    PlayerPrefs.SetInt("ScoreP1", PlayerPrefs.GetInt("ScoreP1") + 1);
                    PlayerController playerController = p2.GetComponent<PlayerController>();
                    playerController.dead = false;
                }
                else if (p2score == true)
                {
                    PlayerPrefs.SetInt("ScoreP2", PlayerPrefs.GetInt("ScoreP2") + 1);
                    PlayerController playerController = p1.GetComponent<PlayerController>();
                    playerController.dead = false;
                }
                flag = true;
                Application.LoadLevel(7);
            }

        } while (flag==false);
    }

    void enableControls()
    {
        p1.enabled = true;
        p2.enabled = true;
    }

}
