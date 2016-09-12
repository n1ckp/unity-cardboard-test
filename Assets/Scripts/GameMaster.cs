using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
  public float spawn_delay_max = 5.0f;
  public float spawn_delay_diff = 0.05f;
  public float spawn_radius = 20.0f;
  float spawn_delay;

  public UnityEngine.UI.Text score_text;

  int player_score = 0;

  bool game_over = false;

  public GameObject zombie_prefab;
  GameObject player;

	// Use this for initialization
	void Start () {
    spawn_delay = spawn_delay_max;
    player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
    spawn_delay -= Time.deltaTime;
    if (spawn_delay <= 0) {
      spawnZombie();
    }
	}

  void spawnZombie() {
    Vector3 _zombie_pos = new Vector3();
    _zombie_pos = RandomCircle (player.transform.position, spawn_radius);
    Instantiate(zombie_prefab, _zombie_pos, Quaternion.identity);
    
    spawn_delay_max -= spawn_delay_diff;
    spawn_delay = spawn_delay_max;
  }

  Vector3 RandomCircle(Vector3 centre, float r){
    float _angle = Random.value * 360;
    Vector3 _pos;
    _pos.x = centre.x + r * Mathf.Sin(_angle * Mathf.Deg2Rad);
    _pos.y = centre.y;
    _pos.z = centre.z + r * Mathf.Cos(_angle * Mathf.Deg2Rad);
    return _pos;
  }

  public void addToScore(int _points) {
    player_score += 1;
    score_text.text = player_score.ToString ();
  }

  public int playerScore() {
    return player_score;
  }

  public void endGame() {
    game_over = true;
    score_text.text = "GAME OVER! \nScore: " + player_score.ToString();
  }

  public bool gameIsOver() {
    return game_over;
  }

}
