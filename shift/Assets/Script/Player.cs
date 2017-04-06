using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  private float healthPoints;
  private float knockbackForce;
  private PlayerTrigger pt;

	// Use this for initialization
	void Start () {
    healthPoints = 3;
    pt = gameObject.GetComponentInChildren<PlayerTrigger> ();
	}

  public float getHealth() {
    return healthPoints;
  }

  public void loseHealth(float hp) {
    this.healthPoints -= hp;
  }

  public bool isDead() {
    return this.healthPoints == 0;
  }

  public void enableHitBox() {
    pt.enableTrigger ();
  }

  public void disableHitBox() {
    pt.disableTrigger ();
  }
	
	// Update is called once per frame
	void Update () {
    if (this.isDead ()) {
      Destroy (gameObject);
    }
	}
}
