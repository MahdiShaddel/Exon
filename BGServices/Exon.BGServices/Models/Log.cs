using System;
using System.Collections.Generic;

namespace Exon.BGServices.Models;

public partial class Log
{
    public int Id { get; set; }

    public int LogType { get; set; }

    public int LogStatus { get; set; }

    public string Message { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime ModifedDate { get; set; }
}
