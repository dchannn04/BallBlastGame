using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

  public static bool IsPlaying;

  public float SpawnRate;
  private float NextSpawn;

//canvas
  public GameObject SpawnPos;
  public GameObject Rocks;
  public GameObject RocksParents;

  public Text ScoreTxt;
  public static int GameScore;

  void Update () {

//If the game is started, and it is next spawn,
//we create rocks with random directions into x and with different localScale

    if(IsPlaying){

      if(Time.time > NextSpawn)
      {
        float RndDir = Random.Range(-150, 150);
        float SizeNum = Random.Range(.7f,1.3f);

        NextSpawn = Time.time + SpawnRate;

        GameObject rocks = Instantiate(Rocks, new Vector2(SpawnPos.transform.
        position.x + RndDir, SpawnPos.transform.position.y),
        SpawnPos.transform.rotation);

        rocks.transform.localScale = new Vector3(SizeNum,SizeNum,0f);

        rocks.transform.SetParent(RocksParents.transform, true);
      }

      ScoreTxt.text = GameScore.ToString();
    }
  }

  public void StartPlaying(){
    Time.timeScale = 1;
    IsPlaying = true;
  }
}
