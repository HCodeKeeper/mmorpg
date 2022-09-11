using System;
using UnityEngine;

namespace Engine
{
    public class MouseToWorldPoint : MonoBehaviour
    {
        public TargetSystem TargetSystemScript;
        public float maxDistance = 1000;
        Vector3 worldPosition;
        // Update is called once per frame

        public RaycastHit Cast()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitData;
            Physics.Raycast(ray, out hitData, maxDistance);
            return hitData;
        }

        private void Update()
        {
            RaycastHit hitData = Cast();
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                TargetSystemScript.HandleTarget(hitData);   
            }
        }
    }
}