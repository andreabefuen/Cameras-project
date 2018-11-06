using UnityEngine;
using System.Collections;

public class UpdatableData : ScriptableObject {

    public event System.Action OnValuesUpdated;

    public bool autoUpdate;

    protected virtual void OnValidate()
    {
        if (autoUpdate)
        {
            NotifyOfUpdateValues();
        }
    }


    public void NotifyOfUpdateValues()
    {
        if(OnValuesUpdated!= null){
            OnValuesUpdated();
        }
    }

}
