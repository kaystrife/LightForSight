using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Diagloue", order = 1)]
public class Dialogue: ScriptableObject{

    public bool isRichText;

    [TextArea(0, 5)]
    public string[] sentences;
}
