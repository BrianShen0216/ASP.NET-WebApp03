﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLLClass
    {
        public DataSet GetUsers_BLL()
        {
            return new DALClass().GetUsers_DAL();
        }
    }
}
