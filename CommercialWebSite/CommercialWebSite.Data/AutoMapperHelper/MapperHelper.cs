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

        public Dest MapSingleObject(Src sourceObject)
        {
            Dest dest = _mapper.Map<Dest>(sourceObject);
            return dest;
        }

        public IEnumerable<Dest> MapCollection(IEnumerable<Src> sourceObjects)
        {
            List<Dest> destObjects = sourceObjects
                .Select(sourceObjects => MapSingleObject(sourceObjects))
                .ToList();
            return destObjects;
        }
    }
}
