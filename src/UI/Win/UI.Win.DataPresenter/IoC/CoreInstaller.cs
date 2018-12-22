using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace UI.Win.DataPresenter.IoC
{
    public class CoreInstaller : IWindsorInstaller
    {
        #region Methods - Public

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<TypedFactoryFacility>();
        }

        #endregion
    }
}