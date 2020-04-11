using Autofac;
using Project.DAL;
using System.Linq;
using System.Reflection;

namespace Project.BLL.Services
{
    //Reserved For use of Dependency Injection in Future
    public static class ContainerConfigBLL 
    {
        //public static IContainer Configure()
        //{
        //    var builder = new ContainerBuilder();

        //    builder.RegisterType<RecordContext>().As<IRecordContext>();

        //    builder.RegisterAssemblyTypes(Assembly.Load(nameof(Project.DAL)))
        //        .Where(x => x.Namespace.Contains("Data"))
        //        .As(x => x.GetInterfaces().FirstOrDefault(i => i.Name == "I" + x.Name));

        //    return builder.Build();
        //}
    }
}
