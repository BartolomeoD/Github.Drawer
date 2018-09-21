
using Autofac;
using Github.Drawer;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class BaseTest
    {
        protected ContainerBuilder Builder;
        protected IContainer Container;

        [SetUp]
        public void _Setup()
        {
            Builder = new ContainerBuilder();
            Builder.RegisterModule(new AutofacModule());
            Container = Builder.Build();
            Setup();
        }

        protected virtual void Setup()
        {}
    }
}