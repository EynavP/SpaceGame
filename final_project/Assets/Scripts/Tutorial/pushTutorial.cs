using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushTutorial : Tutorial
{
    public List<string> Keys = new List<string>();

    public override void CheckIfHappening()
    {
        for (int i = 0; i < Keys.Count; i++)
        {
            if (Input.GetButtonDown(Keys[i]))
            {
                Keys.RemoveAt(i);
                break;
            }
            else if (Input.GetAxis(Keys[i]) > 0f || Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                Keys.RemoveAt(i);
                break;
            }
        }

        if (Keys.Count == 0)
            TutorialManager.Instance.CompletedTutorial();
    }
}
