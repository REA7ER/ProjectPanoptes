using UnityEngine;
using System.Collections;

public class CreatureBase : MonoBehaviour
{
    public float time;
    public bool canFly;
    public bool canSwim;
    public float movementSpeed;
    public bool isHostile;
    public bool isAggressive;
    private LifeSource lifesource;
    public int awarenessLevel;
    private BoxCollider awarenessBox;
    private float previousAwarenessLevel;
    public float HungerRate;
    public float CreatureHunger;
    void Start()
    {
        CreatureHunger = 
        awarenessBox = GetComponent<BoxCollider>();
        awarenessBox.center = transform.position;
        awarenessBox.size = new Vector3(awarenessLevel, awarenessLevel,awarenessLevel);
    }
    void Update()
    {
        
    }
    void ModifyAwareness(float NewAwarenessLevel)
    {
        awarenessBox.size = new Vector3(NewAwarenessLevel, NewAwarenessLevel, NewAwarenessLevel);
    }
    void OnTriggerStay(Collider other)
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, awarenessBox.size);
 
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.tag == "Player"){
            }
            
        }
    }
  
}
