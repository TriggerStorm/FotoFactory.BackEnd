﻿using System;
using System.Collections.Generic;
using FotoFactory.CoreEntities;

namespace FotoFactory.Core.AppService
{
    public interface IPosterRepository
    {
        IEnumerable<Poster> ReadAllPosters();
    }
}
