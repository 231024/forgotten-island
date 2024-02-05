using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
	private static readonly int Speed = Animator.StringToHash("Speed");

	[SerializeField] private NavMeshAgent _agent;
	[SerializeField] private Animator _animator;

	private Ground[] _grounds;

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

	public void MoveTo(Vector3 targetPos)
	{
		_agent.SetDestination(targetPos);
	}
}
