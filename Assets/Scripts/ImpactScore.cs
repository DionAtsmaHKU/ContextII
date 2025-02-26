using System;

[Serializable]
public class ImpactScore
{
    public int embodying = 0;
    public int learning = 0;
    public int imagining = 0;
    public int caring = 0;
    public int organizing = 0;
    public int inspiring = 0;
    public int cocreating = 0;
    public int empowering = 0;
    public int subverting = 0;

    public int Total()
    {
        return embodying + learning + imagining + 
               caring + organizing + inspiring + 
               cocreating + empowering + subverting;
    }

    public void Clear()
    {
        embodying = 0;
        learning = 0;
        imagining = 0;
        caring = 0;
        organizing = 0;
        inspiring = 0;
        cocreating = 0;
        empowering = 0;
        subverting = 0;
    }
}
