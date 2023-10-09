﻿using Core.Domain.Domain;
using Core.Domain;
using MediatR;
using AuthPermissions.BaseCode.CommonCode;

namespace Template.Domain.ClassifiersAggregate
{
    public class CategoryMovement : BaseEntity, IDataKeyFilterReadWrite, IAggregateRoot
    {
        public string Name { get; set; }

        public string DataKey { get; set; }

        public CategoryMovement()
        {
            Name = string.Empty;
            DataKey = string.Empty;
        }

        public CategoryMovement(string name)
        {
            Name = name;
            DataKey = string.Empty;
        }

        public void UpdateCategoryMovement(string name)
        {
            Name = name;
        }

    }
}
