using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionFuego : MonoBehaviour
{
    Animation anim;
    AnimationClip animationClip;
    AnimationCurve salto;
    float duracionSalto = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.AddComponent<Animation>();
        Keyframe[] keysSalto = new Keyframe[3];
        keysSalto[0] = new Keyframe(0,1);
        keysSalto[1] = new Keyframe( duracionSalto / 2, 1.4f);
        keysSalto[2] = new Keyframe( duracionSalto, 1);
        salto = new AnimationCurve(keysSalto);
        animationClip = new AnimationClip();
        animationClip.legacy = true;
        animationClip.SetCurve("", typeof(Transform), "localScale.y", salto);
        animationClip.SetCurve("", typeof(Transform), "localPosition.x", AnimationCurve.Constant(0, duracionSalto, gameObject.transform.localPosition.x));
        animationClip.SetCurve("", typeof(Transform), "localPosition.z", AnimationCurve.Constant(0, duracionSalto, gameObject.transform.localPosition.z));
        anim.AddClip(animationClip, "salto");
        anim.Play("salto");
        anim.wrapMode = WrapMode.Loop;
    }

    // Update is called once per frame
    void Update()
    {1
        
    }
}
