using System.Collections;
using UnityEngine;

public class TargetSearching : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private float _viewDistance;
    [SerializeField] private float _attackingDistance;
    [SerializeField] private float _delayLostTarget;

    private bool _isTargetLost;
    private Coroutine _jobLoseTarget;

    public bool CanAttackTarget => TrySeeTarget(_attackingDistance);

    public bool IsTargetSee { get; private set; }

    private void Update()
    {
        if (IsTargetSee == false)
            SearchTarget();
        else
            SeeTarget();
    }

    public Transform GetTargetTarnsform()
    {
        return _target.transform;
    }

    public Player ToHitTarget()
    {
        return TrySeeTarget(_attackingDistance) ? _target : null;
    }

    private void SearchTarget()
    {
        if (TrySeeTarget(_viewDistance))
            IsTargetSee = true;
    }

    private void SeeTarget()
    {
        float _acceptableAngle = 0.4f;

        float distanceTarget = Vector2.Distance(transform.position, _target.transform.position);
        float visibilityAngle = Vector2.Dot(transform.right, (_target.transform.position - transform.position).normalized);
        _isTargetLost = distanceTarget > _viewDistance || visibilityAngle < _acceptableAngle;

        if (_isTargetLost)
            StartLoseTarget();
    }

    private bool TrySeeTarget(float distance)
    {
        var hit = Physics2D.Raycast(transform.position, transform.right, distance);

        return hit && hit.collider.GetComponent<Player>() == _target;
    }

    private void StartLoseTarget()
    {
        if (_jobLoseTarget != null)
            return;

        _jobLoseTarget = StartCoroutine(LoseTarget());
    }

    private IEnumerator LoseTarget()
    {
        yield return new WaitForSeconds(_delayLostTarget);

        if (_isTargetLost)
            IsTargetSee = false;

        _jobLoseTarget = null;
    }
}
