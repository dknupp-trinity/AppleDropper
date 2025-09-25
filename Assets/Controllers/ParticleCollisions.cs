using System;
using UnityEngine;
using UnityEngine.Rendering;

public class ParticleCollision : MonoBehaviour
{
    public ParticleSystem Apples;
    public ParticleSystem Basket1;
    public ParticleSystem Basket2;
    public ParticleSystem Basket3;
    
    
    public float collisionRadius = 0.15f; // half of particle size

    private ParticleSystem.Particle[] AppleParts;
    private ParticleSystem.Particle[] Basket1Parts;
    private ParticleSystem.Particle[] Basket2Parts;
    private ParticleSystem.Particle[] Basket3Parts;


    void Update()
    {




        int ApplePartCount = Apples.particleCount;
        int Basket1PartCount = Basket1.particleCount;
        int Basket2PartCount = Basket2.particleCount;
        int Basket3PartCount = Basket3.particleCount;

        //grow arrays if needed
        if (AppleParts == null || AppleParts.Length < ApplePartCount)
            AppleParts = new ParticleSystem.Particle[ApplePartCount];
        if (Basket1Parts == null || Basket1Parts.Length < Basket1PartCount)
            Basket1Parts = new ParticleSystem.Particle[Basket1PartCount];
        if (Basket2Parts == null || Basket2Parts.Length < Basket2PartCount)
            Basket2Parts = new ParticleSystem.Particle[Basket2PartCount];
        if (Basket3Parts == null || Basket3Parts.Length < Basket3PartCount)
            Basket3Parts = new ParticleSystem.Particle[Basket3PartCount];

        Apples.GetParticles(AppleParts, ApplePartCount);
        Basket1.GetParticles(Basket1Parts, Basket1PartCount);
        Basket2.GetParticles(Basket2Parts, Basket2PartCount);
        Basket3.GetParticles(Basket3Parts, Basket3PartCount);

        for (int i = 0; i < ApplePartCount; i++)
        {
            Vector3 applePos = AppleParts[i].position;



           
            
            if (applePos.y < Basket1Parts[0].position.y - 1f) //if below baskets
            {
                AppleParts[i].remainingLifetime = 0; // destroy apple
                GameController.Instance.lives -= 1; // lose a life
                break;
            }
            
            for (int j = 0; j < Math.Max(Basket1PartCount, Math.Max(Basket2PartCount, Basket3PartCount)); j++)
            {
                Vector3 basket1Pos = Basket1Parts[j].position;
                Vector3 basket2Pos = Basket2Parts[j].position;
                Vector3 basket3Pos = Basket3Parts[j].position;

                if ((Vector3.SqrMagnitude(applePos - basket1Pos) < collisionRadius * collisionRadius) || (Vector3.SqrMagnitude(applePos - basket2Pos) < collisionRadius * collisionRadius) || (Vector3.SqrMagnitude(applePos - basket3Pos) < collisionRadius * collisionRadius))
                {
                    GameController.Instance.score += 1; // increase score
                    AppleParts[i].remainingLifetime = 0; // destroy apple
                    break; // no need to check other collisions
                }
            }
        }
        Apples.SetParticles(AppleParts, ApplePartCount);
    }
}
