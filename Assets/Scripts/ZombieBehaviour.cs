using UnityEngine;
using System.Collections;

public class ZombieBehaviour : MonoBehaviour {
  GameObject target;
  GameMaster game_master;

  bool dead = false;
  float timeout = 10.0f;

	// Use this for initialization
	void Start () {
    target = GameObject.Find("Player");
    game_master = GameObject.Find ("GameMaster").GetComponent<GameMaster>();
	}
	
	// Update is called once per frame
	void Update () {
    if (dead) {
      if (timeout > 0) {
        timeout -= Time.deltaTime;
      } else {
        Destroy (this.gameObject);
      }
    } else {
      transform.LookAt (target.transform.position);
      transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.03f);
    }
	}

  void OnCollisionEnter(Collision coll) {
    if (!game_master.gameIsOver() && dead == false && coll.gameObject.tag == "projectile") {
      dead = true;
      gameObject.GetComponent<Renderer>().material.color = Color.gray;
      game_master.addToScore(1);
    }
  }
}
