using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

	public float speed;
  private int direction;
  private FacingDirection worldDirection;
  private SpriteRenderer mySpriteRenderer;
  private Vector3 playerPos;
  private float playerYAdjust;
  private float focusAxesPosition; // The axes that the projectile will be moving in
  private float expTime;

  public enum FacingDirection
  {
    Front = 0,
    Right = 1,
    Back = 2,
    Left = 3
  }

	// Use this for initialization
	void Start () {
    this.playerYAdjust = 0.31f;
    this.direction = GameObject.FindWithTag("Player").GetComponent<PlayerController>().getDirection();
    this.playerPos = GameObject.FindWithTag ("Player").transform.position;
    this.worldDirection = (FacingDirection)GameObject.FindWithTag ("GameManager").GetComponent<GameManager> ().getFacingDirection ();
    if (this.worldDirection == FacingDirection.Front) {
      this.focusAxesPosition = this.playerPos.x;
    } else if (this.worldDirection == FacingDirection.Right) {
      this.focusAxesPosition = this.playerPos.z;
    } else if (this.worldDirection == FacingDirection.Back) {
      this.focusAxesPosition = this.playerPos.x;
      this.direction *= -1;
    } else if (this.worldDirection == FacingDirection.Left) {
      this.focusAxesPosition = this.playerPos.z;
      this.direction *= -1;
    }
    this.expTime = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
    if (this.expTime > 0.0f) {
      this.focusAxesPosition += Time.deltaTime * this.speed * this.direction;
      if (this.worldDirection == FacingDirection.Front) {
        transform.position = new Vector3 (this.focusAxesPosition, this.playerPos.y - this.playerYAdjust, this.playerPos.z);
        //GetComponent<Rigidbody2D> ().velocity = new Vector2 (this.direction * this.speed, GetComponent<Rigidbody2D> ().velocity.y);
      } else if (this.worldDirection == FacingDirection.Left) {
        transform.position = new Vector3 (this.playerPos.x, this.playerPos.y - this.playerYAdjust, this.focusAxesPosition);
      } else if (this.worldDirection == FacingDirection.Back) {
        transform.position = new Vector3 (this.focusAxesPosition, this.playerPos.y - this.playerYAdjust, this.playerPos.z);
        //GetComponent<Rigidbody2D> ().velocity = new Vector2 (this.direction * this.speed * -1, GetComponent<Rigidbody2D> ().velocity.y);
      } else if (this.worldDirection == FacingDirection.Right) {
        transform.position = new Vector3 (this.playerPos.x, this.playerPos.y - this.playerYAdjust, this.focusAxesPosition);
      }
      this.expTime -= Time.deltaTime;
    } else {
      Destroy (gameObject);
    }
	}


}
