using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace CommercialWebSite.Data.AutoMapperHelper
{
    public class MapperHelper<Src, Dest>
    {
        private IMapper _mapper;

        public MapperHelper(MapperConfiguration config)
        {
            _mapper = new Mapper(config);
        }

        public Dest MapSingleObjectl(Src sourceObject)
        {
            Dest dest = _mapper.Map<Dest>(sourceObject);
            return dest;
        }

        public List<Dest> MapCollection(List<Src> sourceObjects)
        {
            List<Dest> destObjects = sourceObjects
                .Select(sourceObjects => MapSingleObjectl(sourceObjects))
                .ToList();
            return destObjects;
        }
    }
}
