using UnityEngine;
using System.Collections;

public class LifeSource : MonoBehaviour {

    public float hp,
                 mp,
                 hunger;
    public bool  initated = false;
    public int   currStatus;
    public enum  status { normal = 1,
                          poisoned = 2 };

    void Update() {
        if(initated) {
            // do stuff
        }
    }
}
