using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
using System;

public class SplitScreen : MonoBehaviour {
    public int numberOfPlayer;
    public PlayerController playerprefab;

    //Position player offset
    private float positionX = 10;
    private float positionY = 0;
    private float positionZ = 0;

    //When load level call create 
    private void OnLevelWasLoaded(int level)
    {
        if (level == 1)
        {
            CreatePlayer();
        }



    }

    //Create player prefabs  at position
    public void CreatePlayer()
    {
        int i = 1;
        while (i <= numberOfPlayer)
        {
            //instantiate each player prefab
            PlayerController playerClone = Instantiate(playerprefab);
            playerClone.transform.position = new Vector3(i * positionX, positionY, positionZ);
            SetCameraRatio(playerClone, numberOfPlayer, i);
            
            //Player set controller for each player
            playerClone.player = (XboxController)Enum.ToObject(typeof(XboxController), i);
            i++;
        }
    }

    //Set Display Ratio
    public void SetCameraRatio(PlayerController player, int camareMode, int playerID)
    {
        //set each player screen
        Camera cam = player.GetComponentInChildren<Camera>();
        if (cam != null)
        {
            switch (camareMode)
            {
                case 1:
                    break;
                case 2:
                    cam.rect = new Rect((playerID - 1f) / 2, 0, .5f, 1);
                    break;
                case 3:
                    cam.rect = new Rect(0, (playerID - 1f) / 3, 1, 1 / 3f);
                    break;

                case 4:
                    cam.rect = new Rect(playerID % 2 == 0 ? 0.5f : 0, playerID > 2 ? 0.5f : 0, 0.5f, 0.5f);
                    break;
                default:
                    break;

            }
        }
    }


}
