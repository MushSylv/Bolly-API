using BollyAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BollyAPI.Implementation
{
    public class ApplicationRequestContext : IApplicationRequestContext
    {
        public ApplicationRequestContext()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; }
    }
}
