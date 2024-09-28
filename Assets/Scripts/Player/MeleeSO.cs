using UnityEngine;

[CreateAssetMenu(fileName = "MeleeSO")]
public class MeleeSO : ScriptableObject
{
    public string name;
    public float delay;

    public string primaryAnimName = "primary";
    public string SecondaryAnimName = "secondary";
}
