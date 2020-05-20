using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerController : MonoBehavior {

  [Range(200f,500f)] [SerializeField] private float MoveSpeed = 200f;
  public static float BulletSpeed = 900f;
  public float boundary_xMin, boundary_xMax;
  public float WheelSpeed;
  public float fireRate;
  private float nextFire;
  private float MoveHorizontal;

  public GameObject LWheel, RWheel;
  public GameObject Bullet;
  public GameObject BulletParents;

  void Start () {}

    boundary_xMin = 70f;
    boundary_xMax = Screen.width = 70f;
}

  void Update () {
    if(GameManager.IsPlaying){

      if(Time.time > nextFire)
      {
        nextFire = Time.time + fireRate;
        GameObject bullet = Instantiate(Bullet, new Vector2(transform.position.x,
        transform.position.y + 50f), transform.rotation);
        bullet.transform.SetParent(BulletParents.transform, true);
      }
    }
  }

  void FixedUpdate () {

    MoveHorizontal = Input.GetAxis("Horizontal");

    if( MoveHorizontal > 0){
      LWheel.transform.Rotate (0,0,-WheelSpeed);
      RWheel.transform.Rotate (0,0,-WheelSpeed);
    }
    if( MoveHorizontal < 0){
      LWheel.transform.Rotate (0,0,WheelSpeed);
      RWheel.transform.Rotate (0,0,WheelSpeed);
    }

    Vector3 Movement = new Vector3(MoveHorizontal, 0f, 0f);
    transform.position += Movement * Time.deltaTime * MoveSpeed;

    transform.position = new Vector3(Mathf.Clamp (transform.position.x,
    boundary_xMin, boundary_xMax), transform.position.y);
  }

  void OnCollisionEnter2D(Collision2D col){
    if(col.collider.tag == "Rocks"){
      MoveHorizontal = 0;
      Time.timeScale = 0;
    }
  }
}
