﻿
using ShoppingSystemSematec.Domain.Contracts;

namespace ShoppingSystemSematec.Domain.Entities;

[Entity]
public class Brand: BaseEntity<short>
{
    public string Name { get; set; }
}
