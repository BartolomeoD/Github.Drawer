using Autofac;
using Github.Drawer;
using Github.Drawer.Abstractions;
using Moq;
using Xunit.Abstractions;

namespace Tests
{
    public class BaseTest
    {
        protected ITestOutputHelper Output;
        protected ContainerBuilder Builder;
        protected IContainer Container;
        protected Mock<IDateTimeProvider> MockFakeDateTimeProvider;

        public BaseTest(ITestOutputHelper output)
        {
            MockFakeDateTimeProvider = new Mock<IDateTimeProvider>();
            Builder = new ContainerBuilder();
            Builder.RegisterModule(new AutoFacModule());
            Builder.RegisterInstance(MockFakeDateTimeProvider.Object).As<IDateTimeProvider>();
            Container = Builder.Build();
            Output = output;
        }
    }
}