using Unity;

namespace IoC
{
	public class UnityInitializerSingleton
	{
		protected static UnityInitializerSingleton Instance;
		public IUnityContainer Container { get; }
		private UnityInitializerSingleton()
		{
			Container = new UnityInitializer().GetContainer();
		}

		public static UnityInitializerSingleton GetInstance()
		{
			return Instance ?? (Instance = new UnityInitializerSingleton());
		}
	}
}
