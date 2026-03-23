using System.Collections.Generic;
using UnityEngine;

public class ScoreBarTrigger : MonoBehaviour
{
    ParticleSystem ps;

    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
    List<ParticleSystem.Particle> exit = new List<ParticleSystem.Particle>();

    [SerializeField]
    private ScoreBarController barController;

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("triggered");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collisioned");
    }

    private void OnParticleTrigger()
    {
        //Debug.Log("entered");
        //barController.SetScoreTarget(100);
        // get
        //int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        //int numExit = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);

        //// iterate
        //for (int i = 0; i < numEnter; i++)
        //{
        //    ParticleSystem.Particle p = enter[i];
        //    p.startColor = new Color32(255, 0, 0, 255);
        //    enter[i] = p;
        //}
        //for (int i = 0; i < numExit; i++)
        //{
        //    ParticleSystem.Particle p = exit[i];
        //    p.startColor = new Color32(0, 255, 0, 255);
        //    exit[i] = p;
        //}

        //// set
        //ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        //ps.SetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);

    }
}
