using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour {
  private Player player;

	// Use this for initialization
	void Start () {
    player = transform.parent.GetComponent<Player> ();
	}

  public void enableTrigger() {
    gameObject.GetComponent<BoxCollider> ().isTrigger = true;
  }

  public void disableTrigger() {
    gameObject.GetComponent<BoxCollider> ().isTrigger = false;
  }

  void OnTriggerEnter(Collider col) {
    if (col.gameObject.tag == "enemy")
    {
      player.loseHealth(col.gameObject.GetComponent<Enemy>().getCollisionDmg());
    }
  }

  void OnTriggerExit(Collider col) {}
}
