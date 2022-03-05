//using AutoMapper;

//namespace Application.Mappers
//{
//    public class FixtureMapper
//    {
//        private static readonly Lazy<IMapper> Lazy = new(() =>
//        {
//            var config = new MapperConfiguration(cfg =>
//            {
//                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
//                cfg.AddProfile<FixtureMappingProfile>();
//            });
//            var mapper = config.CreateMapper();
//            return mapper;
//        });
//        public static IMapper Mapper => Lazy.Value;
//    }
//}
