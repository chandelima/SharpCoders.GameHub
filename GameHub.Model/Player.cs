using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHub.Model;

public class Player : User
{
    public string Name { get; private set; } = null!;

    public Player(string name, string username, string password)
        : base(username, password)
    {
        Name = name;
    }
}