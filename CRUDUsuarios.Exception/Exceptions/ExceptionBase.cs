﻿using System.Net;

namespace CRUDUsuarios.Exception.Exceptions
{
    public abstract class ExceptionBase : SystemException
    {
        protected ExceptionBase(string errorMessage): base(errorMessage) { }

        public abstract List<string> GetErros();
        public abstract HttpStatusCode GetStatusCode();

    }
}
