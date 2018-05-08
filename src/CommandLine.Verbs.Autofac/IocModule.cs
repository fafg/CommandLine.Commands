using Autofac;
using System;

namespace CommandLine.Verbs.Autofac
{
    public class IocModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<VerbsParser>().As<IVerbsParser>();
        }
    }
}
