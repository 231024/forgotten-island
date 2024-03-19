using Clipboard;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class MainLifetimeScope : LifetimeScope
{
	[SerializeField] private UnitFactory _factory;
	[SerializeField] private MenuController _menuController;

	protected override void Configure(IContainerBuilder builder)
	{
		builder.RegisterComponent(_factory);
		builder.RegisterComponent(_menuController);

		builder.Register<ClipboardPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
	}
}