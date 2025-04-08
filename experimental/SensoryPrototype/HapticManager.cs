cat <<EOF > HapticManager.cs
using UnityEngine;
using UnityEngine.XR;
using System.Collections.Generic;

public class HapticManager : MonoBehaviour
{
    InputDevice rightHand;

    void Start()
    {
        var devices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, devices);
        if (devices.Count > 0) rightHand = devices[0];
    }

    public void Configure(string sensitivity)
    {
        float amplitude = sensitivity == "High" ? 0.1f : sensitivity == "Medium" ? 0.4f : 0.7f;
        SendHaptic(amplitude);
    }

    public void SendHaptic(float amplitude)
    {
        if (rightHand.isValid)
            rightHand.SendHapticImpulse(0, amplitude, 0.2f);
    }
}
EOF
