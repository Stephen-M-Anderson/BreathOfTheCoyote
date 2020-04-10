using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class CompassHandler : MonoBehaviour
{
    public RawImage compass;
    public Transform player;

    void Update()
    {

        compass.uvRect = new Rect(player.localEulerAngles.y / 360f, 0, 1, 1);

    }
}
