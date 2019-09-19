using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Infra
{
    public interface IBolsaRepository
    {
        List<Rate> Query();
    }
}
