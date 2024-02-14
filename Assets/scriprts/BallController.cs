using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
	public int force;
	Rigidbody2D rigid;
	int scoreP1;
	int scoreP2;
	public Text scoreUIP1;
	public Text scoreUIP2;
	public GameObject panelSelesai;
    public Text txPemenang; 
	AudioSource audio;
	public AudioClip hitSound;
    public HalamanManager hal;
    Vector2 arah;
  // Use this for initialization
    void Start () {
        hal.isPlay = true;
        rigid = GetComponent<Rigidbody2D>();
        int i = Random.Range(-2, 2);
        if (i != 0)
        {
            arah = new Vector2(i, 0).normalized;
            
        }
        else
        {
            arah = new Vector2(2, 0).normalized;
        }
        rigid.AddForce(arah * force);
        scoreP1 = 0;
        scoreP2 = 0;
        audio = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
	      audio.PlayOneShot(hitSound);
          if (coll.gameObject.name == "tepi kanan")
          {
              scoreP1 += 1;
              ResetBall();
              TampilkanScore ();
              Vector2 arah = new Vector2(2, 0).normalized;
              rigid.AddForce(arah * force);
              if (scoreP1 == 5)
                {
                Menang();
                } 
          }
          if (coll.gameObject.name == "tepi kiri")
          {
              scoreP2 += 1;
              ResetBall();
              TampilkanScore ();
              Vector2 arah = new Vector2(-2, 0).normalized;
              rigid.AddForce(arah * force);
              if (scoreP2 == 5)
                {
                Menang();
                } 
          }
              if (coll.gameObject.tag == "Player")
              {
                  float sudut = (transform.position.y - coll.transform.position.y) * 5f;
                  Vector2 arah = new Vector2(rigid.velocity.x, sudut).normalized;
                  rigid.velocity = new Vector2(0, 0);
                  rigid.AddForce(arah * force * 2);
              }
          }
    void ResetBall()
    { 
         transform.localPosition = new Vector2(0, 0);
         rigid.velocity = new Vector2(0, 0);
    }

    void TampilkanScore ()
    {
         Debug.Log ("score P1: " + scoreP1 + "score P2: " + scoreP2);
         scoreUIP1.text = scoreP1 + "";
         scoreUIP2.text = scoreP2 + "";
    }
    void Menang()
    {
        panelSelesai.SetActive(true);
        if (scoreP1 == 5)
        {
            txPemenang.text = "Player Blue WIn!";
        }
        else
        {
            txPemenang.text = "Player Red Win!";
        }
        Destroy(gameObject);
    }
}
