using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class Attacker : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _hitDistance;
    [SerializeField] private float _delayBetweenAttack;
    [SerializeField] private Transform _rayPoint;
    [SerializeField] private SwitchingAnimation _switchingAnimation;

    private InputReader _input;

    public bool CanAttack { get; private set; } = true;

    private void Awake() =>
        _input = GetComponent<InputReader>();

    private void Update()
    {
        if (CanAttack && _input.GetIsAttack)
            StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        CanAttack = false;
        _switchingAnimation.StartAttackBaseAnimation();

        yield return new WaitForSeconds(_delayBetweenAttack);

        CanAttack = true;
    }

    public IEnumerator ApplyDamage()
    {
        while (CanAttack == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(_rayPoint.position, transform.right, _hitDistance);

            if (hit && hit.collider.TryGetComponent(out Enemy enemy))
            {
                    enemy.Health.TakeDamage(_damage);
                    yield break;
            }

            yield return null;
        }
    }
}
