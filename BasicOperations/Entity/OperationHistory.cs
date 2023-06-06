using System;
using System.Collections.Generic;

namespace BasicOperations.Entity.Models;

public partial class OperationHistory
{
    public int Id { get; set; }

    public string Operation { get; set; } = null!;

    public string Result { get; set; } = null!;

    public string? Observations { get; set; }

    public DateTime Date { get; set; }
}
