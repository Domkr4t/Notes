using AutoMapper;
using Notes.Application.Notes.Queries.GetNoteList;
using Notes.Domain;
using System.Reflection;

namespace Notes.Application.Common.Mappings
{
    public class AssemblyMapping : Profile
    {
        public AssemblyMapping(Assembly assembly) =>
            ApplyMappingsFromAssembly(assembly);

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                                .Where(x => x.GetInterfaces()
                                .Any(x => x.IsGenericType &&
                                x.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }

            CreateMap<Note, NoteLookupDto>();
        }
    }
}
