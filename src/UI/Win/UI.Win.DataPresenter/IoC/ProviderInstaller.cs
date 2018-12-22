using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Infrastructure.DataConnector.Connectors;
using Infrastructure.DataConnector.Contracts;
using System.IO.Abstractions;
using Provider.Subscription.Contracts;
using Provider.Subscription.Logic;

namespace UI.Win.DataPresenter.IoC
{
    public class ProviderInstaller : IWindsorInstaller
    {
        #region Methods - Public

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IFileConnector>().ImplementedBy<FileConnector>().LifestyleTransient(),
                Component.For<IFileSystem>().ImplementedBy<FileSystem>(),
                Component.For<IConnectorFactory>().ImplementedBy<ConnectorFactory>().AsFactory(),
                Component.For<IFileParser>().ImplementedBy<FileParser>().DependsOn(
                    Dependency.OnValue("threadCount", 10), 
                    Dependency.OnValue("maxFileSizeInBtyes", 5242880)
                    )
            );
        }

        #endregion
    }
}