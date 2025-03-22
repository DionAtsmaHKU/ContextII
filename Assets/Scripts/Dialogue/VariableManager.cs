using UnityEngine;
using Yarn.Unity;

public class VariableManager : MonoBehaviour
{
    public static VariableManager Instance { get; private set; }
    private InMemoryVariableStorage variables;
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

    // Start is called before the first frame update
    void Start()
    {
        /*
        variables = FindObjectOfType<InMemoryVariableStorage>();
        float testVar = 0;
        variables.TryGetValue("$TestStat", out testVar);
        Debug.Log(testVar);
        variables.SetValue("$TestStat", testVar + 1);
        variables.TryGetValue("$TestStat", out testVar);
        Debug.Log(testVar);
        */
    }

    public void SetYarnFloat(string var, float value)
    {
        variables.SetValue(var, value);
    }

    public void SetYarnBool(string var, bool value)
    {
        variables.SetValue(var, value);
    }

    public float GetYarnFloat(string var)
    {
        float result;
        variables.TryGetValue(var, out result);
        return result;
    }

    public bool GetYarnBool(string var)
    {
        bool result;
        variables.TryGetValue(var, out result);
        return result;
    }
}
