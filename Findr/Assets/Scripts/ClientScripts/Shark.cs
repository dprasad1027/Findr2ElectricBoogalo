using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shark", menuName ="Findr/Create Shark")]
public class Shark : ScriptableObject
{

    public new string name;
    [TextArea(15,20)] public string bio;
    public Sprite sharkSprite;
    public List<Trait> desiredTraits = new List<Trait>();



}
