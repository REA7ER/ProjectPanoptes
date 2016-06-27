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
    public float FindFoodHunger;
 
    private BoxCollider CreatureCollider;
    public int eatRate;
    private bool Collided = true;
    void Start()
    {
        // set creature hunger here
       
        awarenessBox = GetComponentInChildren<BoxCollider>();
        awarenessBox.center = new Vector3(0,transform.position.y,0);

        awarenessBox.size = new Vector3(awarenessLevel, awarenessLevel,awarenessLevel);
        awarenessBox.isTrigger = true;
        CreatureCollider = GetComponent<BoxCollider>();
    }
    void Update()
    {
        
        CreatureHunger -= HungerRate * Time.deltaTime * time;
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
            else if (colliders[i].gameObject.tag == "Food" && CreatureHunger < FindFoodHunger)
            {
                Vector3 targetPosition = colliders[i].transform.position;
                MoveToPoint(targetPosition);  
            }
            else
            {
                CreatureBase othercreaturebase = colliders[i].GetComponent<CreatureBase>();
                if (othercreaturebase)
                {
                    
                    if (othercreaturebase.isAggressive | othercreaturebase.isHostile)
                    {
                        if (isAggressive | isHostile)
                        {
                            Vector3 targetPosition = colliders[i].transform.position;
                            MoveToPoint(targetPosition);
                        }
                        else
                        {
                            Vector3 targetPosition = transform.position - colliders[i].transform.position;
                            MoveToPoint(targetPosition);
                        }
                    }
                }
            }
        }
    }
    void MoveToPoint(Vector3 pos)
    {
        transform.position = Vector3.MoveTowards(transform.position, pos, movementSpeed * 0.005f);

    }
    void OnCollisionStay(Collision other)
    {

        
        if (other.gameObject.tag == "Food" && CreatureHunger < FindFoodHunger && Collided)
        {
                StartCoroutine(Eat(eatRate, other.gameObject));
        }
        
    }
    
    IEnumerator Eat(int EatingRate, GameObject FoodObject)
    {
        Collided = false;
        FoodSourcce foodvariables = FoodObject.GetComponent<FoodSourcce>();
        if (foodvariables.Remaining > 0){
            foodvariables.Remaining -= EatingRate;
            CreatureHunger += EatingRate;
        }
        yield return new WaitForSeconds(1);
        Collided = true;
    }
}
