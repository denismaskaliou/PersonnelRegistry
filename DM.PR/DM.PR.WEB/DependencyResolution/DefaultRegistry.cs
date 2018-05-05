using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace DM.PR.WEB.DependencyResolution
{
    public class DefaultRegistry : Registry
    {
        #region Constructors and Destructors

        public DefaultRegistry()
        {
            Scan(
                scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.With(new ControllerConvention());
                });
        }

        #endregion
    }
}