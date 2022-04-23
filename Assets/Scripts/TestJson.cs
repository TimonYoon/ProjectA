using System.Collections;
using System.Collections.Generic;
using MessagePack;
using UnityEngine;

[MessagePackObject]
public class TestJson
{
    [Key(0)]
    public int Age { get; set; }
    [Key(1)]
    public string FirstName { get; set; }
 
}
