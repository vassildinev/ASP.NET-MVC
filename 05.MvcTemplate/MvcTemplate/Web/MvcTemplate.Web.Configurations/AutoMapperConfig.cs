namespace MvcTemplate.Web.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using AutoMapper;
    using Infrastructure.Mappings;

    public static class AutoMapperConfig
    {
        public static void RegisterMappings(params string[] assemblies)
        {
            var mapperConfiguration = new MapperConfiguration(
                (config) => 
                {
                    LoadAllMappings(config, assemblies);
                });
        }

        private static void LoadAllMappings(IMapperConfiguration config, params string[] assemblies)
        {
            var types = new List<Type>();
            foreach (var assembly in assemblies.Select(a => Assembly.Load(a)))
            {
                types.AddRange(assembly.GetExportedTypes());
            }

            LoadStandardMappings(config, types);
            LoadCustomMappings(config, types);
        }

        private static void LoadStandardMappings(IMapperConfiguration mapperConfiguration, IEnumerable<Type> types)
        {
            var maps = types
                .SelectMany(t => t.GetInterfaces(), (t, i) => new { t, i })
                .Where(type => type.i.IsGenericType &&
                               type.i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                               !type.t.IsAbstract &&
                               !type.t.IsInterface)
                .Select(type => new { Source = type.i.GetGenericArguments()[0], Destination = type.t });

            foreach (var map in maps)
            {
                mapperConfiguration.CreateMap(map.Source, map.Destination);
                mapperConfiguration.CreateMap(map.Destination, map.Source);
            }
        }

        private static void LoadCustomMappings(IMapperConfiguration mapperConfiguration, IEnumerable<Type> types)
        {
            IEnumerable<IHaveCustomMappings> maps = types
                .SelectMany(t => t.GetInterfaces(), (t, i) => new { t, i })
                .Where(type => typeof(IHaveCustomMappings).IsAssignableFrom(type.t) &&
                               !type.t.IsAbstract &&
                               !type.t.IsInterface)
                .Select(type => (IHaveCustomMappings)Activator.CreateInstance(type.t));

            foreach (var map in maps)
            {
                map.CreateMappings(mapperConfiguration);
            }
        }
    }
}
