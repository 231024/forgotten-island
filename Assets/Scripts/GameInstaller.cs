using Clipboard;
using Squads;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class GameInstaller : MonoInstaller
{
	[FormerlySerializedAs("_squadsPrefab")] [SerializeField]
	private SquadsController _prefab;

	[SerializeField] private Transform _parent;

	public override void InstallBindings()
	{
		Container.Bind<ClipboardPresenter>().AsSingle().NonLazy();

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