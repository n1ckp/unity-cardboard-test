using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

  GameMaster game_master;

  void Start() {
    game_master = GameObject.Find ("GameMaster").GetComponent<GameMaster>();
  }

  void OnCollisionEnter(Collision coll) {
    if (!game_master.gameIsOver() && coll.gameObject.tag == "zombie") {
      game_master.endGame ();
    }
  }

}
