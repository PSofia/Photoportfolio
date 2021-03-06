﻿namespace Photoportfolio.Infrastructure.Core
{
    public class GenericResult
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }

    public class AuthResult : GenericResult
    {
        public int UserId { get; set; }
    }
}
