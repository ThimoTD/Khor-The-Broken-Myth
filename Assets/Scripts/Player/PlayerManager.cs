using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //there can only be one player containing one manager
    private static PlayerManager instance;

    //delegate for update per frame
    private PlayerParts[] body;
    public delegate void FrameUpdate();
    public FrameUpdate frameUpdate;

    [Header("Movement Settings")]
    public float speed;
    public float maxSpeed;
    public float jumpingPower;
    //Space(10)]


    private HeadMovement headMovement;

    private void Start()
    {
        instance = this;
        headMovement = new HeadMovement(speed, instance);
    }

    private void Update() => frameUpdate();
}
