using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BigBrainTile : MonoBehaviour
{
    public Transform playerPoint;
    public UnityEvent OnPlayerEnterTile;


    // Start is called before the first frame update
    void Start()
    {
        Player.player.playerMovement.OnMove += OnMove;
    }

    void OnMove()
    {
        Vector3 playerPos = Player.player.playerMovement.GetTargetPos();
        float distance = Vector3.Distance(playerPos, playerPoint.position);

        if(distance < 0.1f)
        {
            OnPlayerEnterTile.Invoke();
        }
    }
}
