using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Entities.Concrete;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<MongoDB_UserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<EmployeeManager>().As<IEmployeeService>().SingleInstance();
            builder.RegisterType<MongoDB_EmployeeDal>().As<IEmployeeDal>().SingleInstance();

            builder.RegisterType<ReceiptManager>().As<IReceiptService>().SingleInstance();
            builder.RegisterType<MongoDB_ReceiptDal>().As<IReceiptDal>().SingleInstance();

            builder.RegisterType<VoucherManager>().As<IVoucherService>().SingleInstance();
            builder.RegisterType<MongoDB_VoucherDal>().As<IVoucherDal>().SingleInstance();

            builder.RegisterType<ReportManager>().As<IReportService>().SingleInstance();
            builder.RegisterType<MongoDB_ReportDal>().As<IReportDal>().SingleInstance();

            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>().SingleInstance();
            builder.RegisterType<MongoDB_OperationClaimDal>().As<IOperationClaimDal>().SingleInstance();

            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>().SingleInstance();
            builder.RegisterType<MongoDB_UserOperationClaimDal>().As<IUserOperationClaimDal>().SingleInstance();



            
           builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
           builder.RegisterType<JWTHelper<User>>().As<ITokenHelper<User>>();
            builder.RegisterType<JWTHelper<Employee>>().As<ITokenHelper<Employee>>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
