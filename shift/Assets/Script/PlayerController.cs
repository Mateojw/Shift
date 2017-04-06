using UnityEngine;
using System.Collections;
using WorldView;

public class PlayerController : MonoBehaviour {

  private int Horizontal = 0;
  private int worldDirection = -1;
  private Player player;

  public Animator anim;
  public float MovementSpeed = 5f;
  public float Gravity = 1f;
  public CharacterController charController;
  private FacingDirection _myFacingDirection;
  private bool isGrounded = true;
  public bool isJumping = false;
  private float jumpForce = 4f;
  public float degree = 0;
  private bool finishedSlerp = true;
  private float lastYAngle;
  private float currentYAngle;

  public Transform firePoint;
  public GameObject ninjaStar;

  void Start() {
    player = GetComponent<Player> ();
    this.lastYAngle = transform.rotation.eulerAngles.y;
    this.currentYAngle = transform.rotation.eulerAngles.y;
  }

  public FacingDirection CmdFacingDirection {
    set{ _myFacingDirection = value;
    }
  }

  public int getDirection() {
    return worldDirection;
  }

  // Update is called once per frame
  void Update () {
    if (!player.isDead ()) {
      if (Input.GetAxis ("Horizontal") < 0) {
        Horizontal = -1;
        worldDirection = -1;
        gameObject.GetComponentInChildren<SpriteRenderer> ().flipX = false;
      } else if (Input.GetAxis ("Horizontal") > 0) {
        Horizontal = 1; 
        worldDirection = 1;
        gameObject.GetComponentInChildren<SpriteRenderer> ().flipX = true;
      } else {
        Horizontal = 0;
      }

      if (gameObject.GetComponent<CharacterController> ().isGrounded) {
        this.isGrounded = true;
        this.isJumping = false;
      } else {
        this.isGrounded = false;
      }

      if (Input.GetKeyDown (KeyCode.Space) && this.isGrounded) {
        this.isJumping = true;
      }

      if (anim) {
        anim.SetInteger ("Horizontal", Horizontal);

        float moveFactor = MovementSpeed * Time.deltaTime * 10f;
        MoveCharacter (moveFactor);

      }

      transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, degree, 0), 8 * Time.deltaTime);

      this.currentYAngle = transform.rotation.eulerAngles.y;
      if (Mathf.Abs (this.currentYAngle - this.lastYAngle) < 1) {
        this.finishedSlerp = true;
      } else {
        this.finishedSlerp = false;
      }
      this.lastYAngle = this.currentYAngle;

      if (this.finishedSlerp) {
        player.enableHitBox ();
      }

      if (Input.GetKeyDown (KeyCode.Return)) {
        Instantiate (ninjaStar, firePoint.position, firePoint.rotation);
      }
    }

  }

  private void MoveCharacter(float moveFactor)
  {
    Vector3 trans = Vector3.zero;
    if(_myFacingDirection == FacingDirection.Front)
    {
      trans = new Vector3(Horizontal* moveFactor, -Gravity * moveFactor, 0f);
    }
    else if(_myFacingDirection == FacingDirection.Right)
    {
      trans = new Vector3(0f, -Gravity * moveFactor, Horizontal* moveFactor);
    }
    else if(_myFacingDirection == FacingDirection.Back)
    {
      trans = new Vector3(-Horizontal* moveFactor, -Gravity * moveFactor, 0f);
    }
    else if(_myFacingDirection == FacingDirection.Left)
    {
      trans = new Vector3(0f, -Gravity * moveFactor, -Horizontal* moveFactor);
    }
    if (isJumping) {
      Vector3 jumpUp = transform.TransformDirection(Vector3.up) * jumpForce;
      charController.Move (jumpUp * Time.deltaTime);
    }

    charController.SimpleMove (trans);
  }
  public void UpdateToFacingDirection(FacingDirection newDirection, float angle)
  {
    _myFacingDirection = newDirection;
    degree = angle;

  }
}
