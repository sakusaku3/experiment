﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace serialize
{
    [CollectionDataContract(Namespace = "")]
    public class NewObser<T> : ObservableCollection<T>
    {
    }
}
