using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public Text LivesText;

    // Update is called once per frame
    void Update()
    {
        LivesText.text = PlayerStats.Lives.ToString() + "LIVES";
    }
}
