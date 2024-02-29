using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Services.Mappers
{
    public static class MappingExtension
    {
        public static void IgnoreNull<TSource, TDestination>(this IMappingExpression<TSource, TDestination> map)
        {
            map.ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != default));
        }
    }
}
