using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowTotalImpact : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreUI;

    // Update is called once per frame
    void Update()
    {
        scoreUI.text = "Score: \n" +
           "Embodying: " + Sculpture.Instance.impactScore.embodying + "\n" + 
           "Learning: " + Sculpture.Instance.impactScore.learning + "\n" +
           "Imagining: " + Sculpture.Instance.impactScore.imagining + "\n" +
           "Caring: " + Sculpture.Instance.impactScore.caring + "\n" +
           "Organizing: " + Sculpture.Instance.impactScore.organizing + "\n" +
           "Inspiring: " + Sculpture.Instance.impactScore.inspiring + "\n" +
           "Co-creating: " + Sculpture.Instance.impactScore.cocreating + "\n" +
           "Empowering: " + Sculpture.Instance.impactScore.empowering + "\n" +
           "Subverting: " + Sculpture.Instance.impactScore.subverting
            ;
    }
}
