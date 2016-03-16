using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour {

    public float duration;
    public GameObject hitBox;

    public Animator anim;
    // Use this for initialization
    void Start ()
    {
        //anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        duration -= Time.deltaTime;
        if (duration <= 0)
        {                      
            anim.Play("Explosion");
            Invoke("explode", 0.5f);              
        }
    }

    void explode()
    {
        Destroy(gameObject);
    }
}
