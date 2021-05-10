﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actio.Domain.Services
{
    public interface IEncrypter
    {
        string GetSalt();

        string GetHash(string value, string salt);
    }
}
