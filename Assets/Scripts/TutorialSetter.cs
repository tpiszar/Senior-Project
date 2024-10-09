using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSetter : MonoBehaviour
{
    public bool towerPlacing = true;
    public bool energyBlast = true;
    public bool fireball = true;
    public bool lightning = true;
    public bool barrier = true;
    public bool teleport = true;
    public bool crystalTower = true;
    public bool flameOrbTower = true;

    //private void Awake()
    //{
    //    Set();
    //}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Set()
    {
        TutorialManager.towerPlacing = towerPlacing;
        TutorialManager.energyBlast = energyBlast;
        TutorialManager.fireball = fireball;
        TutorialManager.lightning = lightning;
        TutorialManager.barrier = barrier;
        TutorialManager.teleport = teleport;
        TutorialManager.crystalTower = crystalTower;
        TutorialManager.flameOrbTower = flameOrbTower;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}