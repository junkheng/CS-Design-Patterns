using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace DecoratorDependencyInjector
{
    public interface IReportingService
    {
        void Report();
    }

    public class ReportingService : IReportingService
    {
        public void Report()
        {
            Console.WriteLine("Here is your report");
        }
    }

    public class ReportingServiceWithLogging : IReportingService
    {
        private IReportingService decorated;

        public ReportingServiceWithLogging(IReportingService decorated)
        {
            this.decorated = decorated;
        }
        public void Report()
        {
            Console.WriteLine("Commencing logs...");
            decorated.Report();
            Console.WriteLine("End of logs...");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var b = new ContainerBuilder(); //Autofac stuff
            b.RegisterType<ReportingService>().Named<IReportingService>("reporting");
            b.RegisterDecorator<IReportingService>(
                (context, service) => new ReportingServiceWithLogging(service), "reporting");
        }
    }
}
