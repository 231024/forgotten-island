using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Squads
{
	public class SquadsController : MonoBehaviour
	{
		[FormerlySerializedAs("_viewSquads")] [SerializeField]
		private SquadsView _squadsView;

		[Inject] private SquadsManager _manager;
		[Inject] private SignalBus _signalBus;

		private void Start()
		{
			_signalBus.Subscribe<NewSquadMemberAddedSignal>(EventInstantiate);
			_squadsView.IdsInstance += SquadsViewOnIdsInstance;
			_squadsView.ReInstantiate(_manager.KeysArray);
		}

		private void OnDestroy()
		{
			_squadsView.IdsInstance -= SquadsViewOnIdsInstance;
			_signalBus.Unsubscribe<NewSquadMemberAddedSignal>(EventInstantiate);
		}

		private void EventInstantiate()
		{
			_squadsView.ReInstantiate(_manager.KeysArray);
		}

		private void SquadsViewOnIdsInstance(string id)
		{
			_manager.PickSquad(id);
		}
	}
}
