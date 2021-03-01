using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionSalto : MonoBehaviour
{
    Animation anim;
    AnimationClip animationClip;
    AnimationCurve salto;
    float alturaSalto = 0.5f;
    float duracionSalto = 0.6f;
    // Start is called before the first frame update
    void Start()
    {
        
        float tiempoInicial = Random.Range(0, 1f);
        anim = gameObject.AddComponent<Animation>();
        Keyframe[] keysSalto = new Keyframe[3];
        keysSalto[0] = new Keyframe(tiempoInicial, 0);
        keysSalto[1] = new Keyframe(tiempoInicial + duracionSalto/2, alturaSalto);
        keysSalto[2] = new Keyframe(tiempoInicial + duracionSalto, 0) ;
        salto = new AnimationCurve(keysSalto);
        animationClip = new AnimationClip();
        animationClip.legacy = true;
        animationClip.SetCurve("", typeof(Transform), "localPosition.y", salto);
        animationClip.SetCurve("", typeof(Transform), "localPosition.x", AnimationCurve.Constant(0, duracionSalto, gameObject.transform.localPosition.x));
        animationClip.SetCurve("", typeof(Transform), "localPosition.z", AnimationCurve.Constant(0, duracionSalto, gameObject.transform.localPosition.z));
        anim.AddClip(animationClip, "salto");
        anim.Play("salto");
        anim.wrapMode = WrapMode.Loop;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
