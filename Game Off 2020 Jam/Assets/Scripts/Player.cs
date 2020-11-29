using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;

    public bool playerDead = false;

    public string DeathTag;

    public float y_offset;

    public string CP1_Tag;
    public string CP2_Tag;
    public string CP3_Tag;

    [Range(0,3)]
    public int NumOfCP;

    [SerializeField]
    private int CurrentCP = 0;
    public GameObject Checkpoint_0;
    public GameObject Checkpoint_1;
    public GameObject Checkpoint_2;
    public GameObject Checkpoint_3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(DeathTag))
        {
            playerDead = true;
            KillPlayer();
            Debug.Log("Player Died!");
        }
        if (collision.collider.CompareTag(CP1_Tag) & CurrentCP > 1)
        {
            CurrentCP = 1;
            Debug.Log("New Checkpoint!");
        }
        if (collision.collider.CompareTag(CP2_Tag) & CurrentCP > 2)
        {
            CurrentCP = 2;
            Debug.Log("New Checkpoint!");
        }
        if (collision.collider.CompareTag(CP3_Tag) & CurrentCP > 3)
        {
            CurrentCP = 3;
            Debug.Log("New Checkpoint!");
        }
    }

    public void KillPlayer()
    {
        if (playerDead)
        {
            if (CurrentCP == 0)
            {
                player.transform.position = Checkpoint_0.transform.position + new Vector3(0,y_offset,0);
                playerDead = false;
                Debug.Log("Player had respawn!");
            }
            if (CurrentCP == 1 && NumOfCP > 0)
            {
                player.transform.position = Checkpoint_1.transform.position + new Vector3(0, y_offset, 0);
                playerDead = false;
                Debug.Log("Player had respawn!");
            }
            if (CurrentCP == 2 && NumOfCP > 1)
            {
                player.transform.position = Checkpoint_2.transform.position + new Vector3(0, y_offset, 0);
                playerDead = false;
                Debug.Log("Player had respawn!");
            }
            if (CurrentCP == 3 && NumOfCP > 2)
            {
                player.transform.position = Checkpoint_3.transform.position + new Vector3(0, y_offset, 0);
                playerDead = false;
                Debug.Log("Player had respawn!");
            }
        }
    }

}
