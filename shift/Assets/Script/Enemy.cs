using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldView;

public enum Mob {
  SLIME = 0
}

public class Enemy : MonoBehaviour {
  public Mob id;
  private GameManager gm;
  private GameObject player;
  public float exptime;
  private float focusAxesPosition;
  private float collisionDmg;

	// Use this for initialization
	void Start () {
    gm = GameObject.FindWithTag ("GameManager").GetComponent<GameManager>();
	}

  public float getCollisionDmg() {
    if (this.id == Mob.SLIME) {
      collisionDmg = 1.0f;
    }
    return collisionDmg;
  }

	// Update is called once per frame
	void Update () {
    
	}
}
