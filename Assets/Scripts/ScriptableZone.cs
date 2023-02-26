using System;
using UnityEngine;

[Serializable]
public class Zone
{
    public Vector3 ZonePosition;
    public Quaternion ZoneRotation;
}

[CreateAssetMenu(menuName = "New Zone")]
public class ScriptableZone : ScriptableObject
{
    public Zone[] Zone;   
}
