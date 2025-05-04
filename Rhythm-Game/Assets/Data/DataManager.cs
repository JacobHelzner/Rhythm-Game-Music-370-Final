using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class dataEntry
{
    public string key;
    public float value;
}

public class DataManager : MonoBehaviour
{
    public dataEntry[] entries;
    public Hashtable entryLookupTable;

    void Awake()
    {
        entryLookupTable = new Hashtable();
    }

    public void loadData()
    {
        foreach (dataEntry entry in entries)
        {
            entry.value = PlayerPrefs.GetFloat(entry.key);
        }
        buildEntryLookupTable();
    }

    public void buildEntryLookupTable()
    {
        entryLookupTable.Clear();
        foreach (dataEntry entry in entries)
        {
            entryLookupTable.Add(entry.key, entry.value);
        }
    }

    public void setDataValue(string key, float value)
    {
        if (entryLookupTable.ContainsKey(key))
        {
            entryLookupTable[key] = value;
        }
    }

    public float getDataValue(string key)
    {
        if (entryLookupTable.ContainsKey(key))
        {
            return (float)entryLookupTable[key];
        }
        else
        {
            return 0f;
        }
    }

    public void saveData()
    {
        foreach (dataEntry entry in entries)
        {
            entry.value = (float)entryLookupTable[entry.key];
            PlayerPrefs.SetFloat(entry.key, entry.value);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
