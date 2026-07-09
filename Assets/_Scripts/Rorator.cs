using UnityEngine;

namespace VISlab.Standard
{

    public class Rorator : MonoBehaviour
    {
        #region Attributes

        [SerializeField]
        private float rotationSpeed = 5.0f;

        #endregion


        void Start()
        {

        }

        void Update()
        {

            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        }
    }


}