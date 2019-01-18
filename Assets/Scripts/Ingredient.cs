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
        Tool collidedTool = otherCollider.gameObject.GetComponent<Tool>();
        if (collidedTool == null)
        {
            return;
        }

        if (collidedTool.toolType == toolType)
        {
            HitByTool();
        }
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
        Transform parentTransform = gameObject.GetComponentInParent<Transform>();
        Instantiate(preparedForm, parentTransform.position, parentTransform.rotation);
        Destroy(gameObject);
    }
}
