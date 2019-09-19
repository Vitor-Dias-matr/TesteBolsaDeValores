using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Aplication
{
    public interface IRateRepository
    {
        List<Rate> Query();
    }
}
