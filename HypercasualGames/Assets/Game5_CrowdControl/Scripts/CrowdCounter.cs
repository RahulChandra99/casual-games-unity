using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CrowdCounter : MonoBehaviour
{
    [SerializeField] private TextMeshPro crowdCounterText;
    [SerializeField] private Transform runnersParentTransform;

    private void Update()
    {
        crowdCounterText.text = runnersParentTransform.childCount.ToString();
    }
}
