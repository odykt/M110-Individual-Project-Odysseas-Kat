using UnityEngine;

namespace Assets.Scripts._Utils
{
    internal class Follow : MonoBehaviour
    {
        [SerializeField] Transform target;
        [SerializeField] Vector3 direction;
        [SerializeField] float distance;
        [SerializeField]
        bool setInAwake;
        private void Awake()
        {
            if (setInAwake)
            {
                // Calculate the initial distance and directional vector between the GameObject and the target
                if (target != null)
                {
                    distance = Vector3.Distance(transform.position, target.position);
                    direction = (target.position - transform.position).normalized;
                }
            }
        }

        private void LateUpdate()
        {
            // Follow the target by updating the position directly or using the directional vector
            if (target != null)
            {
                this.transform.position = target.position -  distance * direction;

            }
        }

    }
}
