using UnityEngine;

[RequireComponent(typeof(Animator))]
public class IKAnimation : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private Transform _handObject;
    [SerializeField] private Transform _headObject;

    [SerializeField] private float _distanceToTrackHeadObject = 2.0f;

    [SerializeField] private bool isIKActive = true;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (isIKActive)
        {
            if (_handObject)
            {
                _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);

                _animator.SetIKPosition(AvatarIKGoal.LeftHand, _handObject.position);
                _animator.SetIKPosition(AvatarIKGoal.RightHand, _handObject.position);
            }

            if (_headObject)
            {
                if ((_headObject.position - transform.position).sqrMagnitude <= _distanceToTrackHeadObject * _distanceToTrackHeadObject)
                {
                    _animator.SetLookAtWeight(1);
                    _animator.SetLookAtPosition(_headObject.position);
                } else
                {
                    _animator.SetLookAtWeight(0);
                }
                
            }
        }
        else 
        {
            _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
            _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            _animator.SetLookAtWeight(0);
        }

    }

}
