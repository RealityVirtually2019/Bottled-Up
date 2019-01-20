using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public GameObject preparedForm;
    public ToolType toolType;
    public int hitsToPrepare = 3;
    private int hitsSoFar = 0;

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
        Tool collidedTool = otherCollider.GetComponent<Tool>();
        if (collidedTool != null && collidedTool.toolType == toolType && collidedTool.IsActiveTool())
        {
            collidedTool.DeactivateTool();
            HitByTool();
        }
        Cauldron collidedCauldron = otherCollider.GetComponent<Cauldron>();
        if (collidedCauldron != null)
        {
            OnCauldronContact();
        }
    }

    private void OnCauldronContact()
    {
        DestroyIngredient();
    }

    private void DestroyIngredient()
    {
        //TODO: Add flair
        Destroy(gameObject);
    }

    private void HitByTool()
    {
        hitsSoFar += 1;
        if (hitsSoFar == hitsToPrepare)
        {
            ReplaceWithPreparedForm();
        }
    }

    private void ReplaceWithPreparedForm()
    {
        // Transform parentTransform = gameObject.GetComponentInParent<Transform>();
        Instantiate(preparedForm, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
