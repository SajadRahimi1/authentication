﻿namespace Utility.Setting;

public class JwtConfig
{
    public string SecrectKey { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
}