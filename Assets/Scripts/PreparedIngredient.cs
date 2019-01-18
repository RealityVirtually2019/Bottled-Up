using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparedIngredient : MonoBehaviour
{
    public IngredientType ingredientType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        //Tool collidedTool = otherCollider.GetComponent<Tool>();
        //Cauldron collidedCauldron = otherCollider.GetComponent<Cauldron>();
        //if (collidedCauldron != null)
        //{
        //    OnCauldronContact();
        //}
    }

    public void OnCauldronEnter()
    {
        //TODO: Special effects
        Destroy(gameObject);
    }
}
