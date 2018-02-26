using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DojoLeague.Models
{
    public class DojoList
    {
        private DataFactory _data;
        public List<String> _nameList= new List<string>();

        public DojoList(DataFactory data)
        {
            _data = data;
            var result = _data.GetNinjas();
            foreach (var dojo in result)
            {
                _nameList.Add(dojo.name);
            }

        }
    }
}

