using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class BeginScene : MonoBehaviour
{
    public PostProcessVolume workVolume;
    public CinemachineVirtualCamera virtualCam;

    public AnimationCurve workAnim;
    private CinemachineBasicMultiChannelPerlin noise;


    [Sirenix.OdinInspector.ReadOnly] public int workTime = 0;
    public int totalWorkTime = 7;

    public void Start()
    {

        noise  = virtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void DoWork()
    {
        workTime++;
    }

    public void Update()
    {
        float target = workAnim.Evaluate(1f * workTime / totalWorkTime);
        workVolume.weight = Mathf.Lerp(workVolume.weight, target, Time.deltaTime * 3f);

        noise.m_AmplitudeGain = Mathf.Lerp( noise.m_AmplitudeGain , (target + 0.2f ) * 3f , Time.deltaTime * 3f );
    }

}
