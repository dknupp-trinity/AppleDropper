using System.Runtime.CompilerServices;
using UnityEngine;

public class AppleParticleController : MonoBehaviour
{

    private float dropSpeed;
    void Start()
    {
        var main = GetComponent<ParticleSystem>().main;
        dropSpeed = GameController.Instance.dropInterval;
    }

    // Update is called once per frame
    void Update()
    {

        //set particle gravity to game controller gravity
        var main = GetComponent<ParticleSystem>().main;
        main.gravityModifier = GameController.Instance.gravity;

        //set particle emission rate to match game controller drop interval
        ParticleSystem dropper = GetComponent<ParticleSystem>();
        var emission = dropper.emission;
        emission.rateOverTime = 1f / GameController.Instance.dropInterval;

        
    }
}
