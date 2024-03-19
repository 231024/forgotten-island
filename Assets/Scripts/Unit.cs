using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour, IProduct
{
	private static readonly int Speed = Animator.StringToHash("Speed");
	private static readonly int Attack = Animator.StringToHash("Attack");

	[SerializeField] private NavMeshAgent _agent;
	[SerializeField] private Animator _animator;
	[SerializeField] private float _attackRate;

	private float _lastHit;

	private void Update()
	{
		Debug.Log("Unit");
		_animator.SetFloat(Speed, _agent.velocity.magnitude);
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

	public int Weight { get; private set; }

	public void MoveTo(Vector3 targetPos)
	{
		_agent.SetDestination(targetPos);
	}

	public GameObject GO => gameObject;

	public void SetWeight(int tmpWeight)
	{
		Weight = tmpWeight;
	}
}