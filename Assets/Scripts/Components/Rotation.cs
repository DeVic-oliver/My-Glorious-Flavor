namespace Assets.Scripts.Components
{
    using System.Collections;
    using UnityEngine;
    
    public class Rotation : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void LateUpdate()
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 200, Space.Self);
        }
    }
}