using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StringColour 
{
   public static string AddColour(this string text)
    {
        return text
            .Replace("ATTACK", "<color=red>ATTACK</color>")
            .Replace("POWER", "<color=#CDCD00>POWER</color>")
            .Replace("ACTIONS", "<color=green>ACTIONS</color>")
            .Replace("DEFENCE", "<color=blue>DEFENCE</color>")
            .Replace("HEALTH", "<color=brown>HEALTH</color>")
            .Replace("CARDS", "<color=purple>CARDS</color>")
            .Replace("(-)", "<color=orange>(-)</color>")
            .Replace("(+)", "<color=cyan>(+)</color>")
            .Replace("TATICS", "<color=purple>TATICS</color>");
    }
}
