using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sculpture : MonoBehaviour
{
    public static Sculpture Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public ImpactScore impactScore;
    public List<ImpactScore> itemScores = new List<ImpactScore>();

    public void UpdateScore()
    {
        impactScore.Clear();
        foreach (var item in itemScores)
        {
            impactScore.embodying += item.embodying;
            impactScore.learning += item.learning;
            impactScore.imagining += item.imagining;
            impactScore.caring += item.caring;
            impactScore.organizing += item.organizing;
            impactScore.inspiring += item.inspiring;
            impactScore.cocreating += item.cocreating;
            impactScore.empowering += item.empowering;
            impactScore.subverting += item.subverting;
        }
    }
}
