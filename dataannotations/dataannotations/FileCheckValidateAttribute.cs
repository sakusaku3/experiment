using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace dataannotations
{
    class FileCheckValidateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string pass)
            {
                return File.Exists(pass);
            }

            return true;
        }
    }
}
