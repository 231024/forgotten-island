using Command;
using Zenject;

namespace Squads
{
	public class SquadsInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			SignalBusInstaller.Install(Container);

			Container.DeclareSignal<NewSquadMemberAddedSignal>();

			Container.BindInterfacesAndSelfTo<Calculator>().AsSingle().NonLazy();
			Container.BindInterfacesAndSelfTo<SquadsManager>().AsSingle().NonLazy();
			Container.Bind<SquadsController>().FromComponentOnRoot();
		}
	}
}
