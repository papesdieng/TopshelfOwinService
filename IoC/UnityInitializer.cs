using Unity;

namespace IoC
{
	public class UnityInitializer : IUnityInitializer
	{
		private readonly IUnityContainer _container;

		public UnityInitializer()
		{
			_container = new UnityContainer();
			//Registration Right here
		}

		public IUnityContainer GetContainer()
		{
			return _container;
		}
	}
}
