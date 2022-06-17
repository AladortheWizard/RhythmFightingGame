using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bug : MonoBehaviour
{
    public void bugReport()
    {
        Application.OpenURL("https://github.com/AladortheWizard/RhythmFightingGame/issues/new?assignees=AladortheWizard&labels=bug&template=bug_report.md&title=%5BBUG%5D");
    }
}
