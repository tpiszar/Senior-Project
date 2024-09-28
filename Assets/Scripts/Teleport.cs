using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Teleport : MonoBehaviour
{
    public static Teleport Instance;

    public event Action<float> onTeleport;

    public Transform[] bases;
    public GameObject[] crystals;
    public Transform playerBase;

    public int curBase = 0;

    public float easeInTime = 0.3f;
    public float teleportTime;

    public CustomProvider vignetteProvider;

    public void startTeleport(int baseNum)
    {
        if (onTeleport != null)
        {
            onTeleport(easeInTime);
        }

        crystals[curBase].SetActive(true);

        curBase = baseNum;

        vignetteProvider.setLocomotion(LocomotionPhase.Moving);

        Invoke("doTeleport", easeInTime);
    }

    public void doTeleport()
    {
        playerBase.position = bases[curBase].position;
        playerBase.rotation = bases[curBase].rotation;

        crystals[curBase].SetActive(false);

        Invoke("endTeleport", easeInTime);
    }

    public void endTeleport()
    {
        vignetteProvider.setLocomotion(LocomotionPhase.Done);
    }

    public void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            doTeleport();
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Teleport.Instance.onTeleport += onTeleport;
    }

    public bool testDone = true;

    // Update is called once per frame
    void Update()
    {
        if (!testDone)
        {
            startTeleport(curBase);
            testDone = true;
        }
    }
}