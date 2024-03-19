using Clipboard;
using Squads;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
	[SerializeField] private SquadsController _prefab;
	[SerializeField] private Transform _parent;
	[SerializeField] private MenuController _menuController;
	[SerializeField] private UnitFactory _factory;

	public override void InstallBindings()
	{
		Container.Bind<ClipboardPresenter>().AsSingle().NonLazy();
		Container.Bind<MenuController>().FromInstance(_menuController).AsSingle();
		Container.Bind<UnitFactory>().FromInstance(_factory).AsSingle();

#if ANDROID_BUILD && !UNITY_EDITOR
		Container.Bind<IClipboard>().To<AndroidClipboard>().AsSingle().NonLazy();
#elif IOS_BUILD && !UNITY_EDITOR
		Container.Bind<IClipboard>().To<iOSClipboard>().AsSingle().NonLazy();
#else
		Container.Bind<IClipboard>().To<UnityClipboard>().AsSingle().NonLazy();
#endif

		Container.InstantiatePrefab(_prefab, _parent);
	}
}
