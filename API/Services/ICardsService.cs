﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Common;

namespace API.Services
{
    public interface ICardsService
    {
        IEnumerable<Card> FetchCards();
    }
}
