using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldView;

public class Enemy : MonoBehaviour {
  public int id;
  private GameManager gm;
  public float exptime;
  public enum ENEMIES {
    SLIME = 0,
  }
	// Use this for initialization
	void Start () {
    gm = GameObject.FindWithTag ("GameManager").GetComponent<GameManager>();
	}
	
  public void updateOrientation(int direction) {
      transform.Rotate (0, 90 * direction, 0);
  }

	// Update is called once per frame
	void Update () {
    
	}
}
