using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionCohete : MonoBehaviour
{
    Animation anim;
    AnimationClip animationClip;
    AnimationClip aLaLuna;
    AnimationCurve temblor;
    AnimationCurve despegue;
    AnimationCurve despegueZ;
    float duracionTemblor = 12, alturaTemblor = 0.1f;
    float duracionVuelo = 10;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.AddComponent<Animation>();
        //Animator animator = gameObject.AddComponent<Animator>();
        //animator.applyRootMotion = false;
        float alturaCohete = gameObject.transform.position.y;
        float tiempoTranscurrido = 0, tiempoTemblor = 0.2f;
        List<Keyframe> keysTemblor = new List<Keyframe>();
        while (tiempoTranscurrido <= duracionTemblor)
        {
            keysTemblor.Add(new Keyframe(tiempoTranscurrido, alturaCohete));
            keysTemblor.Add(new Keyframe(tiempoTranscurrido + tiempoTemblor / 2, alturaCohete + alturaTemblor));
            keysTemblor.Add(new Keyframe(tiempoTranscurrido + tiempoTemblor, alturaCohete));
            tiempoTranscurrido += tiempoTemblor;
        }
        keysTemblor.Add(new Keyframe(duracionTemblor + duracionVuelo-4, 300));
        keysTemblor.Add(new Keyframe(duracionTemblor + duracionVuelo, 422));
        temblor = new AnimationCurve(keysTemblor.ToArray());


        List<Keyframe> keysDespegue = new List<Keyframe>();
        keysDespegue.Add(new Keyframe(0, 0));
        keysDespegue.Add(new Keyframe(duracionTemblor, 0));
        keysDespegue.Add(new Keyframe(duracionTemblor + duracionVuelo, 75));
        despegue = new AnimationCurve(keysDespegue.ToArray());

        despegueZ = AnimationCurve.EaseInOut(duracionTemblor + duracionVuelo-4, 0.0f, duracionVuelo + duracionTemblor, 420.0f);

        animationClip = new AnimationClip();
        animationClip.legacy = true;

        animationClip.SetCurve("", typeof(Transform), "localEulerAngles.x", despegue);
        animationClip.SetCurve("", typeof(Transform), "localPosition.y", temblor);
        anim.AddClip(animationClip, "temblor");


        despegueZ = AnimationCurve.EaseInOut(0, gameObject.transform.position.z, duracionVuelo, 430.0f);

        aLaLuna = new AnimationClip();
        aLaLuna.legacy = true;
        aLaLuna.SetCurve("", typeof(Transform), "localPosition.z", despegueZ);
        aLaLuna.SetCurve("", typeof(Transform), "localPosition.x", AnimationCurve.Constant(0, duracionVuelo, 0));
        aLaLuna.SetCurve("", typeof(Transform), "localPosition.y", AnimationCurve.Constant(0, duracionVuelo, 422));
        anim.AddClip(aLaLuna, "despegue");
        anim.Play("temblor");
        anim.PlayQueued("despegue");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
