﻿using Core.Domain.Domain;
using Core.Domain;

namespace Template.Domain.ClassifiersAggregate
{
    public class CategoryGlobal : BaseEntity
    {
        public string Name { get; set; }

        public CategoryGlobal(string name)
        {
            Name = name;
        }
    }
}
