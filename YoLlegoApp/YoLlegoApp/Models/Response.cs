﻿using System;
using System.Collections.Generic;
using System.Text;

namespace YoLlegoApp.Models
{
    public class Response
    {
        public bool IsSucess { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
    }
}
}
