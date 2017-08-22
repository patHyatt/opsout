using System.Collections.Generic;

public class QueryArgument
{
    public int ProjectId { get; set; }

    public HashSet<string> Environments { get; set; }
}