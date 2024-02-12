using UnityEngine;
using UnityEngine.AI;

public class DogUnit : MonoBehaviour, IProduct
{
	private static readonly int Speed = Animator.StringToHash("Speed");
	private static readonly int Attack = Animator.StringToHash("Attack");

	[SerializeField] private NavMeshAgent _agent;
	[SerializeField] private Animator _animator;
	[SerializeField] private float _attackRate;

	private Ground[] _grounds;
	private float _lastHit;

	private void Awake()
	{
		_grounds = FindObjectsOfType<Ground>();
	}

	private void Update()
	{
		_animator.SetFloat(Speed, _agent.velocity.magnitude);
	}

	private void OnEnable()
	{
		foreach (var ground in _grounds)
		{
			ground.GroundTouched += MoveTo;
		}
	}

	private void OnDisable()
	{
		foreach (var ground in _grounds)
		{
			ground.GroundTouched -= MoveTo;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		var tree = other.gameObject.GetComponent<Tree>();

		if (tree == null)
		{
			return;
		}

		if (_lastHit + _attackRate < Time.time)
		{
			tree.Hit();
			_lastHit = Time.time;
			_animator.SetTrigger(Attack);
		}
	}

	public void MoveTo(Vector3 targetPos)
	{
		_agent.SetDestination(targetPos);
	}
}
