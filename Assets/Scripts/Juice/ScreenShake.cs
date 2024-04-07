using System.Collections;
using UnityEngine;
using Cinemachine;
using System.Runtime.CompilerServices;
public class ScreenShake : MonoBehaviour
{
    public float globalShakeForce = 1f;


    public void ShakeCamera(CinemachineImpulseSource source)
    {
        source.GenerateImpulseWithForce(globalShakeForce);
    }


}