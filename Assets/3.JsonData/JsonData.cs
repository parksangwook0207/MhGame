using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonData : Singleton<JsonData>
{
    [System.Serializable]
    public class TData
    {
        public int att;
        public int hp;
        public int attdis;
        public float attdelay;
    }

    [System.Serializable]
    public class TurretData
    {
        public List<TData> turret;
    }

    [SerializeField] TextAsset turrentJson;
    [HideInInspector] public TurretData tData;

    // Start is called before the first frame update
    void Start()
    {
        tData.turret = new List<TData>();
        // form 가져오는 거 
        // to  json으로 보내는거
        JsonUtility.FromJson<TurretData>(turrentJson.text);
        Debug.Log(tData.turret[0].hp);
    }

    
}
