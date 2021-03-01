using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionCamara : MonoBehaviour
{

    Animation anim;
    AnimationClip primeraEscena;
    AnimationClip segundaEscena;
    AnimationClip terceraEscena;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.AddComponent<Animation>();
        List<Keyframe> keysPrimeraEscenaX = new List<Keyframe>();
        keysPrimeraEscenaX.Add(new Keyframe(0, 247));
        keysPrimeraEscenaX.Add(new Keyframe(2, 230));
        keysPrimeraEscenaX.Add(new Keyframe(4, 124));
        keysPrimeraEscenaX.Add(new Keyframe(6, 115));
        keysPrimeraEscenaX.Add(new Keyframe(8, -115));
        AnimationCurve primeraEscenaX = new AnimationCurve(keysPrimeraEscenaX.ToArray());

        List<Keyframe> keysPrimeraEscenaY = new List<Keyframe>();
        keysPrimeraEscenaY.Add(new Keyframe(0, 64));
        keysPrimeraEscenaY.Add(new Keyframe(2, 12));
        AnimationCurve primeraEscenaY = new AnimationCurve(keysPrimeraEscenaY.ToArray());

        List<Keyframe> keysPrimeraEscenaZ = new List<Keyframe>();
        keysPrimeraEscenaZ.Add(new Keyframe(0, -152));
        keysPrimeraEscenaZ.Add(new Keyframe(2, -48.6f));
        keysPrimeraEscenaZ.Add(new Keyframe(4, -10));
        keysPrimeraEscenaZ.Add(new Keyframe(6, -28));
        keysPrimeraEscenaZ.Add(new Keyframe(8, -28));
        AnimationCurve primeraEscenaZ = new AnimationCurve(keysPrimeraEscenaZ.ToArray());

        List<Keyframe> keysPrimeraEscenaRot = new List<Keyframe>();
        keysPrimeraEscenaRot.Add(new Keyframe(0, -42));
        keysPrimeraEscenaRot.Add(new Keyframe(2, -70));
        keysPrimeraEscenaRot.Add(new Keyframe(4, -117));
        keysPrimeraEscenaRot.Add(new Keyframe(6, -154));
        keysPrimeraEscenaRot.Add(new Keyframe(8, -228));
        AnimationCurve primeraEscenaRot = new AnimationCurve(keysPrimeraEscenaRot.ToArray());

        primeraEscena = new AnimationClip();
        primeraEscena.legacy = true;
        primeraEscena.SetCurve("", typeof(Transform), "localPosition.x", primeraEscenaX);
        primeraEscena.SetCurve("", typeof(Transform), "localPosition.y", primeraEscenaY);
        primeraEscena.SetCurve("", typeof(Transform), "localPosition.z", primeraEscenaZ);
        primeraEscena.SetCurve("", typeof(Transform), "localEulerAngles.y", primeraEscenaRot);
        anim.AddClip(primeraEscena, "primera escena");


        List<Keyframe> keysSegundaEscenaX = new List<Keyframe>();
        keysSegundaEscenaX.Add(new Keyframe(10, 0));
        AnimationCurve segundaEscenaX = new AnimationCurve(keysSegundaEscenaX.ToArray());

        List<Keyframe> keysSegundaEscenaY = new List<Keyframe>();
        keysSegundaEscenaY.Add(new Keyframe(10, 13));
        AnimationCurve segundaEscenaY = new AnimationCurve(keysSegundaEscenaY.ToArray());

        List<Keyframe> keysSegundaEscenaZ = new List<Keyframe>();
        keysSegundaEscenaZ.Add(new Keyframe(10, -30));
        AnimationCurve segundaEscenaZ = new AnimationCurve(keysSegundaEscenaZ.ToArray());

        List<Keyframe> keysSegundaEscenaRot = new List<Keyframe>();
        keysSegundaEscenaRot.Add(new Keyframe(10, -53));
        AnimationCurve segundaEscenaRot = new AnimationCurve(keysSegundaEscenaRot.ToArray());

        segundaEscena = new AnimationClip();
        segundaEscena.legacy = true;
        segundaEscena.SetCurve("", typeof(Transform), "localPosition.x", segundaEscenaX);
        segundaEscena.SetCurve("", typeof(Transform), "localPosition.y", segundaEscenaY);
        segundaEscena.SetCurve("", typeof(Transform), "localPosition.z", segundaEscenaZ);
        segundaEscena.SetCurve("", typeof(Transform), "localEulerAngles.x", segundaEscenaRot);
        anim.AddClip(segundaEscena, "segunda escena");

        List<Keyframe> keysTerceraEscenaX = new List<Keyframe>();
        keysTerceraEscenaX.Add(new Keyframe(0,97));
        keysTerceraEscenaX.Add(new Keyframe(10, 122));
        AnimationCurve terceraEscenaX = new AnimationCurve(keysTerceraEscenaX.ToArray());

        List<Keyframe> keysTerceraEscenaY = new List<Keyframe>();
        keysTerceraEscenaY.Add(new Keyframe(0, 353));
        keysTerceraEscenaY.Add(new Keyframe(10, 424));
        AnimationCurve terceraEscenaY = new AnimationCurve(keysTerceraEscenaY.ToArray());

        List<Keyframe> keysTerceraEscenaZ = new List<Keyframe>();
        keysTerceraEscenaZ.Add(new Keyframe(0, 230));
        keysTerceraEscenaZ.Add(new Keyframe(10, 568));
        AnimationCurve terceraEscenaZ = new AnimationCurve(keysTerceraEscenaZ.ToArray());

        List<Keyframe> keysTerceraEscenaRotX = new List<Keyframe>();
        keysTerceraEscenaRotX.Add(new Keyframe(0, 21));
        keysTerceraEscenaRotX.Add(new Keyframe(10, 13));
        AnimationCurve terceraEscenaRotX = new AnimationCurve(keysTerceraEscenaRotX.ToArray());

        List<Keyframe> keysTerceraEscenaRotY = new List<Keyframe>();
        keysTerceraEscenaRotY.Add(new Keyframe(0, -140));
        keysTerceraEscenaRotY.Add(new Keyframe(10, -156));
        AnimationCurve terceraEscenaRotY = new AnimationCurve(keysTerceraEscenaRotY.ToArray());

        List<Keyframe> keysTerceraEscenaRotZ = new List<Keyframe>();
        keysTerceraEscenaRotZ.Add(new Keyframe(0, 9));
        keysTerceraEscenaRotZ.Add(new Keyframe(10, 6));
        AnimationCurve terceraEscenaRotZ = new AnimationCurve(keysTerceraEscenaRotZ.ToArray());

        terceraEscena = new AnimationClip();
        terceraEscena.legacy = true;
        terceraEscena.SetCurve("", typeof(Transform), "localPosition.x", terceraEscenaX);
        terceraEscena.SetCurve("", typeof(Transform), "localPosition.y", terceraEscenaY);
        terceraEscena.SetCurve("", typeof(Transform), "localPosition.z", terceraEscenaZ);
        terceraEscena.SetCurve("", typeof(Transform), "localEulerAngles.x", terceraEscenaRotX);
        terceraEscena.SetCurve("", typeof(Transform), "localEulerAngles.y", terceraEscenaRotY);
        terceraEscena.SetCurve("", typeof(Transform), "localEulerAngles.z", terceraEscenaRotZ);
        anim.AddClip(terceraEscena, "tercera escena");

        anim.PlayQueued("primera escena", QueueMode.PlayNow);
        anim.PlayQueued("segunda escena", QueueMode.CompleteOthers);
        anim.PlayQueued("tercera escena", QueueMode.CompleteOthers);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
