using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IJournalItem
{
    string NameKey { get; }
    string DescriptionKey { get; }
}
