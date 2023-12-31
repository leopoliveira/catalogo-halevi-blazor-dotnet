﻿using Halevi.Core.Domain.Entities.Base;

namespace Halevi.Core.Domain.Entities
{
    public class Category : BaseEntitiy
    {
        public string Name { get; set; } = null!;

        public ICollection<Product> Products { get; } = new List<Product>();
    }
}
