using Oculus.Interaction.Input;
using UnityEngine;

namespace Oculus.Interaction.Samples.PalmMenu
{
    /// <summary>
    /// Positions the menu at the left wrist and keeps it facing a specified target GameObject.
    /// </summary>
    public class MatchWristPositionLookAtTarget : MonoBehaviour
    {
        [SerializeField, Interface(typeof(IHand))]
        private Object _leftHand;

        [SerializeField]
        private GameObject _target; // The GameObject the menu should always look at

        private IHand LeftHand { get; set; }

        protected virtual void Awake()
        {
            LeftHand = _leftHand as IHand;
        }

        private void Update()
        {
            // Ensure the target and left hand are assigned
            if (_target == null || LeftHand == null) return;

            // Get the left wrist pose
            Pose wristPose;
            if (LeftHand.GetJointPose(HandJointId.HandWristRoot, out wristPose))
            {
                // Set the position to the left wrist position
                this.transform.position = wristPose.position;

                // Make the menu look at the target GameObject
                Vector3 directionToTarget = (_target.transform.position - this.transform.position).normalized;
                this.transform.rotation = Quaternion.LookRotation(directionToTarget);
            }
        }
    }
}
